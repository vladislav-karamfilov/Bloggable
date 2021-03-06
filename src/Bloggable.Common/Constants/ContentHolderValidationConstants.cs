﻿namespace Bloggable.Common.Constants
{
    public static class ContentHolderValidationConstants
    {
        public const int TitleMinLength = 5;

        public const int TitleMaxLength = 100;

        public const int ContentMinLength = 10;

        public const int ContentMaxLength = 10000;

        public const int SummaryMaxLength = 3000;

        public const int UrlMinLength = 3;

        public const int UrlMaxLength = 2048;

        public const int MetaDescriptionMinLength = 5;

        public const int MetaDescriptionMaxLength = 300;

        public const int MetaKeywordsMinLength = 5;

        public const int MetaKeywordsMaxLength = 100;

        public const string PermalinkRegEx = @"[a-zA-Zа-яА-Я0-9\-_]+";
    }
}
