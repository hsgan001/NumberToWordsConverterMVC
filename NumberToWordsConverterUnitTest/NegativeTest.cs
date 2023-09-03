using Microsoft.AspNetCore.Mvc;
using NumberToWordsConverterMVC.Controllers;
using NumberToWordsConverterMVC.Models;

namespace NumberToWordsConverterUnitTest
{
    /// <summary>
    /// Negative Unit Test for Converter Controller 
    /// </summary>
    public class NegativeTest
    {
        /// <summary>
        /// Negative Decimal Test Case
        /// </summary>
        [Fact]
        public void NegativeDecimal()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = -0.01m };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(!model.IsSuccess);
            Assert.Equal("Something went wrong with your request, please contact the administrator.", model.Words);
        }

        /// <summary>
        /// Negative dollar Test Case
        /// </summary>
        [Fact]
        public void NegativeDollars()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = -10 };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(!model.IsSuccess);
            Assert.Equal("Something went wrong with your request, please contact the administrator.", model.Words);
        }

        /// <summary>
        /// Exceeding Maximum Value Test Case
        /// </summary>
        [Fact]
        public void ExceedingMaximumValue()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 100000000000000000 };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(!model.IsSuccess);
            Assert.Equal("Something went wrong with your request, please contact the administrator.", model.Words);
        }

        /// <summary>
        /// Three Decimal Places Test Case
        /// </summary>
        [Fact]
        public void ThreeDecimalPlaces()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 123.456m };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(!model.IsSuccess);
            Assert.Equal("Something went wrong with your request, please contact the administrator.", model.Words);
        }

        /// <summary>
        /// Zero Input Test Case
        /// </summary>
        [Fact]
        public void ZeroInput()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 0 };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(!model.IsSuccess);
            Assert.Equal("Something went wrong with your request, please contact the administrator.", model.Words);
        }
    }
}