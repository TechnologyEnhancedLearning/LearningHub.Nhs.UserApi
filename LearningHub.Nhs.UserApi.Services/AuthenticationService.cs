﻿namespace LearningHub.Nhs.UserApi.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using LearningHub.Nhs.Models.Common;
    using LearningHub.Nhs.UserApi.Services.Interface;
    using LearningHub.Nhs.UserApi.Shared;
    using LearningHub.Nhs.UserApi.Shared.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Login = elfhHub.Nhs.Models.Common.Login;

    /// <summary>
    /// The authentication service.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Settings settings;
        private readonly IElfhUserService elfhUserService;
        private readonly ILogger<AuthenticationService> logger;
        private readonly IPasswordManagerService passwordManagerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="elfhUserService">The user service.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="passwordManagerService">The password manager service.</param>
        public AuthenticationService(
            IElfhUserService elfhUserService,
            IOptions<Settings> settings,
            ILogger<AuthenticationService> logger,
            IPasswordManagerService passwordManagerService)
        {
            this.elfhUserService = elfhUserService;
            this.settings = settings.Value;
            this.logger = logger;
            this.passwordManagerService = passwordManagerService;
        }

        /// <inheritdoc/>
        public async Task<LoginResultInternal> AuthenticateAsync(Login login)
        {
            var loginResult = await this.CheckUserCredentialsAsync(login);

            if (loginResult.IsAuthenticated)
            {
               //// await this.elfhUserService.RecordSuccessfulSigninAsync(loginResult.UserId);
                this.logger.LogInformation("User {lhuserid} has successfully authenticated.", loginResult.UserId);
            }
            else if (loginResult.UserId > 0)
            {
               //// await this.elfhUserService.RecordUnsuccessfulSigninAsync(loginResult.UserId);
                this.logger.LogWarning("User {lhuserid} has unsuccessfully authenticated. {errMsg}", loginResult.UserId, loginResult.ErrorMessage);
            }

            return loginResult;
        }

        /// <summary>
        /// The check user credentials sso async.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The <see cref="LoginResultInternal"/>.</returns>
        public async Task<LoginResultInternal> CheckUserCredentialsSsoAsync(int userId)
        {
            var user = await this.elfhUserService.GetByIdAsync(userId);

            string errorMessage = null;

            if (user == null)
            {
                errorMessage = "User Id is incorrect";
            }
            else if (user.PasswordLifeCounter >= this.settings.MaxLogonAttempts)
            {
                errorMessage = "This account is locked. Please contact the support team if you need help.";
            }
            else if (!user.Active || user.ActiveFromDate > DateTimeOffset.Now || user.ActiveToDate < DateTimeOffset.Now)
            {
                errorMessage = "This account is not active. Please contact the support team if you need help.";
            }

            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                await this.elfhUserService.RecordSuccessfulSigninAsync(userId);

                return new LoginResultInternal
                {
                    IsAuthenticated = true,
                    UserId = user.Id,
                    UserName = user.UserName,
                };
            }

            if (user != null)
            {
                await this.elfhUserService.RecordUnsuccessfulSigninAsync(userId);
            }

            return new LoginResultInternal { IsAuthenticated = false, ErrorMessage = errorMessage };
        }

        /// <summary>
        /// The check user credentials.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<LoginResultInternal> CheckUserCredentialsAsync(Login login)
        {
            var user = await this.elfhUserService.GetUserDetailForAuthenticateAsync(login.Username);

            LoginResultInternal loginResult = new LoginResultInternal();
            var errMsgs = new
            {
                userPassIncorrect = "The username or password is incorrect",
                accountNotActive = "This account is not active. Please contact the support team if you need help.",
                openAthensSignIn =
                    "If yours is an OpenAthens Account, you must login via the \"Sign on with OpenAthens\" option and not directly here.",
                restrictedLogin =
                    "This account has a restricted login. Please log in via your organisations website instead.",
                oneMoreChance = "You have one more chance to enter correct answers before your account becomes locked!",
                accountLocked = "This account is locked. Please contact the support team if you need help.",
            };

            if (user == null)
            {
                loginResult.ErrorMessage = errMsgs.userPassIncorrect;
                loginResult.IsAuthenticated = false;
            }
            else if (!user.Active || user.ActiveFromDate > DateTimeOffset.Now || user.ActiveToDate < DateTimeOffset.Now)
            {
                loginResult.ErrorMessage = errMsgs.accountNotActive;
                loginResult.IsAuthenticated = false;
            }
            else if (user.RestrictToSso)
            {
                if (user.OpenAthensUserAttributeId.HasValue && user.OpenAthensUserAttributeId.Value > 0)
                {
                    loginResult.ErrorMessage = errMsgs.openAthensSignIn;
                }
                else
                {
                    loginResult.ErrorMessage = errMsgs.restrictedLogin;
                }

                loginResult.IsAuthenticated = false;
            }
            else if (user.PasswordLifeCounter >= this.settings.MaxLogonAttempts)
            {
                loginResult.ErrorMessage = errMsgs.accountLocked;
                loginResult.IsAuthenticated = false;
            }
            else
            {
                if (this.passwordManagerService.Base64MD5HashDigest(login.Password) == user.PasswordHash)
                {
                    loginResult.ErrorMessage = string.Empty;
                    loginResult.IsAuthenticated = true;
                    loginResult.UserName = user.UserName;
                }
                else
                {
                    // Temporarily increment password counter as password check failed.
                    // This will be committed in a later operation to the DB.
                    user.PasswordLifeCounter++;
                    if (user.PasswordLifeCounter >= this.settings.MaxLogonAttempts)
                    {
                        loginResult.ErrorMessage = errMsgs.accountLocked;
                    }
                    else if (user.PasswordLifeCounter == this.settings.MaxLogonAttempts - 1)
                    {
                        loginResult.ErrorMessage = errMsgs.oneMoreChance;
                    }
                    else
                    {
                        loginResult.ErrorMessage = errMsgs.userPassIncorrect;
                    }

                    loginResult.IsAuthenticated = false;
                }
            }

            loginResult.UserId = user?.Id ?? 0;

            return loginResult;
        }
    }
}