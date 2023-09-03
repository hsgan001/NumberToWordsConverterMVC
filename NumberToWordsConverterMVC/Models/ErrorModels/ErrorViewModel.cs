namespace NumberToWordsConverterMVC.Models.ErrorModels;

/// <summary>
/// Error view model 
/// </summary>
public class ErrorViewModel : NumberConversionModel
{
    /// <summary>
    /// Error message to display
    /// </summary>
    public string? ErrorMessage { get; set; }
}