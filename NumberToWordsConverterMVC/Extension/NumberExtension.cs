namespace NumberToWordsConverterMVC.Extension;

/// <summary>
/// Number's extension
/// </summary>
public static class NumberExtension
{
    private static readonly string[] Ones =
    {
        "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN",
        "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
    };

    private static readonly string[] Tens = { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
    private static readonly string[] Thousands = { "", "THOUSAND", "MILLION", "BILLION", "TRILLION" };

    /// <summary>
    /// Convert number to words
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string ToWords(this decimal number)
    {
        long dollars = (long)Math.Floor(number);
        long cents = (long)((number - dollars) * 100);

        if (dollars == 0)
            return $"{ConvertToWords(cents)} {(cents > 1 ? "CENTS" : "CENT")}";

        string words = $"{ConvertToWords(dollars)} {(dollars > 1 ? "DOLLARS" : "DOLLAR")}";
        return cents > 0 ? words + $" AND {ConvertToWords(cents)} {(cents > 1 ? "CENTS" : "CENT")}" : words;
    }

    private static string ConvertToWords(long number)
    {
        if (number == 0)
            return Ones[0];

        string words = "";
        int groupIndex = 0;

        while (number > 0)
        {
            if (number % 1000 != 0)
            {
                string convertWords = ConvertByThreeDigits((int)(number % 1000));
                words = $"{convertWords} {Thousands[groupIndex]} {words}";
            }

            number /= 1000;
            groupIndex++;
        }

        return words.Trim();
    }

    private static string ConvertByThreeDigits(int number)
    {
        string convertedWords = "";

        int hundredsDigit = number / 100;
        int tensDigit = (number % 100) / 10;
        int onesDigit = number % 10;

        if (hundredsDigit > 0)
        {
            convertedWords += $"{Ones[hundredsDigit]} HUNDRED";
            if (tensDigit > 0 || onesDigit > 0)
                convertedWords += " AND ";
        }

        switch (tensDigit)
        {
            case > 1:
                convertedWords += Tens[tensDigit];
                if (onesDigit > 0)
                    convertedWords += $"-{Ones[onesDigit]}";
                break;

            case 1:
                convertedWords += Ones[number % 100];
                break;

            default:
                if (onesDigit > 0)
                    convertedWords += Ones[onesDigit];
                break;
        }

        return convertedWords.Trim();
    }
}