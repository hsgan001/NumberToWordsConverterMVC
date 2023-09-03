using Microsoft.AspNetCore.Mvc;
using NumberToWordsConverterMVC.Controllers;
using NumberToWordsConverterMVC.Models;

namespace NumberToWordsConverterUnitTest
{
    /// <summary>
    /// Positive Unit Test for Converter Controller 
    /// </summary>
    public class PositiveTest
    {
        /// <summary>
        /// Minimum Input Value Test Case
        /// </summary>
        [Fact]
        public void MinimumInputValue()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 0.01m };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(model.IsSuccess);
            Assert.Equal("ONE CENT", model.Words);
        }

        /// <summary>
        /// Maximum To Trillion Input Value Test Case
        /// </summary>
        [Fact]
        public void MaximumToTrillion()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 1000000000000 };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(model.IsSuccess);
            Assert.Equal("ONE TRILLION DOLLARS", model.Words);
        }

        /// <summary>
        /// Whole dollar Test Case
        /// </summary>
        [Fact]
        public void WholeDollar()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 100 };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(model.IsSuccess);
            Assert.Equal("ONE HUNDRED DOLLARS", model.Words);
        }

        /// <summary>
        /// Cents Test Case
        /// </summary>
        [Fact]
        public void Cents()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 0.99m };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(model.IsSuccess);
            Assert.Equal("NINETY-NINE CENTS", model.Words);
        }

        /// <summary>
        /// Dollars And Cents Test Case
        /// </summary>
        [Fact]
        public void DollarsAndCents()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 123.45m };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(model.IsSuccess);
            Assert.Equal("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS", model.Words);
        }

        /// <summary>
        /// Large Amount Test Case
        /// </summary>
        [Fact]
        public void LargeAmount()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 1234567.89m };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(model.IsSuccess);
            Assert.Equal("ONE MILLION TWO HUNDRED AND THIRTY-FOUR THOUSAND FIVE HUNDRED AND SIXTY-SEVEN DOLLARS AND EIGHTY-NINE CENTS", model.Words);
        }

        /// <summary>
        /// Leading Zero Test Case
        /// </summary>
        [Fact]
        public void LeadingZero()
        {
            ConverterController controller = new();
            NumberConversionModel numberConversionModel = new() { Number = 000123.45m };

            ViewResult? result = controller.NumberToWords(numberConversionModel) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<NumberConversionModel>(result.Model);
            var model = (NumberConversionModel)result.Model;
            Assert.True(model.IsSuccess);
            Assert.Equal("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS", model.Words);
        }
    }
}