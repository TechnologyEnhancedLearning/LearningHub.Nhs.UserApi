namespace LearningHub.Nhs.Auth.Models.Account
{
    /// <summary>
    /// The UserEmailViewModel model.
    /// </summary>
    public class UserEmailViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user have multiple email.
        /// </summary>
        public bool HasMultipleUsers { get; set; }

        /// <summary>
        /// Gets or sets the redirect url.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets the My account url.
        /// </summary>
        public string MyAccountUrl { get; set; }

        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
        public string UserName { get; set; }
    }
}
