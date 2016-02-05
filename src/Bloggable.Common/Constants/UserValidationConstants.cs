namespace Bloggable.Common.Constants
{
    public static class UserValidationConstants
    {
        public const int UserNameMinLength = 5;

        public const int UserNameMaxLength = 40;

        public const string UserNameRegEx = @"^[a-zA-Z]([._]?[a-zA-Z0-9]+)+$";

        public const int EmailMinLength = 6;

        public const int EmailMaxLength = 80;

        public const int PasswordMinLength = 6;

        public const int PasswordMaxLength = 100;

        public const int NameMinLength = 5;

        public const int NameMaxLength = 30;
    }
}
