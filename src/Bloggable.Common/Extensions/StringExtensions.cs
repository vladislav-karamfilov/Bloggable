namespace Bloggable.Common.Extensions
{
    using System;
    using System.Text;

    public static class StringExtensions
    {
        public static string ToUrl(this string uglyString)
        {
            if (uglyString == null)
            {
                throw new ArgumentNullException(nameof(uglyString));
            }

            var resultString = new StringBuilder(uglyString.Length);
            var isLastCharacterDash = false;

            uglyString = uglyString.Replace("C#", "CSharp");
            uglyString = uglyString.Replace("C++", "CPlusPlus");

            foreach (var character in uglyString)
            {
                if (char.IsLetterOrDigit(character))
                {
                    resultString.Append(character);
                    isLastCharacterDash = false;
                }
                else if (!isLastCharacterDash)
                {
                    resultString.Append('-');
                    isLastCharacterDash = true;
                }
            }

            return resultString.ToString().Trim('-');
        }

        public static string PascalCaseToText(this string input)
        {
            string resultText = null;

            if (input != null)
            {
                const char WhiteSpace = ' ';

                var result = new StringBuilder();
                var currentWord = new StringBuilder();
                var abbreviation = new StringBuilder();

                var previous = WhiteSpace;
                var inWord = false;
                var isAbbreviation = false;

                for (var i = 0; i < input.Length; i++)
                {
                    var symbolToAdd = input[i];

                    if (char.IsUpper(symbolToAdd) && previous == WhiteSpace && !inWord)
                    {
                        inWord = true;
                        isAbbreviation = true;
                        abbreviation.Append(symbolToAdd);
                    }
                    else if (char.IsUpper(symbolToAdd) && inWord)
                    {
                        abbreviation.Append(symbolToAdd);
                        currentWord.Append(WhiteSpace);
                        symbolToAdd = char.ToLower(symbolToAdd);
                    }
                    else if (char.IsLower(symbolToAdd) && inWord)
                    {
                        isAbbreviation = false;
                    }
                    else if (symbolToAdd == WhiteSpace)
                    {
                        result.Append(isAbbreviation && abbreviation.Length > 1 ? abbreviation.ToString() : currentWord.ToString());
                        currentWord.Clear();
                        abbreviation.Clear();

                        if (result.Length > 0)
                        {
                            abbreviation.Append(WhiteSpace);
                        }

                        inWord = false;
                        isAbbreviation = false;
                    }

                    previous = symbolToAdd;
                    currentWord.Append(symbolToAdd);
                }

                if (currentWord.Length > 0)
                {
                    result.Append(isAbbreviation && abbreviation.Length > 1 ? abbreviation.ToString() : currentWord.ToString());
                }

                resultText = result.ToString();
            }

            return resultText;
        }
    }
}
