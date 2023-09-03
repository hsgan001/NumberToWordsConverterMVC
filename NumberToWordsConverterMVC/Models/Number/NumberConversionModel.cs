namespace NumberToWordsConverterMVC.Models;

/// <summary>
/// Number Conversion Model
/// </summary>
public class NumberConversionModel
{
    /// <summary>
    /// Is success converted status
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Input Number
    /// </summary>
    public decimal? Number { get; set; }

    /// <summary>
    /// Converted Words
    /// </summary>
    public string? Words { get; set; }
}
