namespace Bloggable.Common.Constants
{
    public static class TagValidationConstants
    {
        public const int TagNameMinLength = 2;

        public const int TagNameMaxLength = 30;

        public const string MergedTagsRegEx = @"^[, ]*([a-zA-Zа-яА-Я0-9]+[a-zA-Zа-яА-Я0-9#+\-]{1,29}([, ]*))+$";
    }
}
