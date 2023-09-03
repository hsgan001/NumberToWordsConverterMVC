using Microsoft.AspNetCore.Mvc;
using NumberToWordsConverterMVC.Constants;
using NumberToWordsConverterMVC.Extension;
using NumberToWordsConverterMVC.Models;
using NumberToWordsConverterMVC.Models.ErrorModels;
using System.Text.RegularExpressions;

namespace NumberToWordsConverterMVC.Controllers
{
    /// <summary>
    /// Converter controller to handle conversion related module
    /// </summary>
    public class ConverterController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterController"/> class.
        /// </summary>
        public ConverterController()
        {
        }

        /// <summary>
        /// Method convert number to words
        /// </summary>
        /// <param name="numberConversion"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NumberToWords(NumberConversionModel numberConversion)
        {
            string? numberToString = numberConversion.Number?.ToString();

            if (string.IsNullOrWhiteSpace(numberToString) || !Regex.IsMatch(numberToString, @"^(?!0*(\.0{1,2})?$)([0-9]\d{0,12}(\.\d{1,2})?|0\.\d{1,2})$"))
            {
                numberConversion.IsSuccess = false;
                numberConversion.Words = ErrorMessage.GeneralErrorMessage;
                return View("Index", numberConversion);
            }

            if (ModelState.IsValid)
            {
                numberConversion.IsSuccess = true;
                numberConversion.Words = numberConversion?.Number?.ToWords();
            }

            return View("Index", numberConversion);
        }

        public IActionResult Index()
        {
            NumberConversionModel numberConversion = new();
            return View(numberConversion);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel() { ErrorMessage = ErrorMessage.GeneralErrorMessage });
        }
    }
}