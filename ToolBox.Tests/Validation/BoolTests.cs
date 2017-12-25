using Xunit;
using ToolBox.Validations;

namespace ToolBox.Validations.Tests
{
    public class BoolTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(true, true)]
        public void SomeFalse_WhenIsValidInput_ReturnsFalse(params bool[] values)
        {
            //Act
            var result = Bool.SomeFalse(values);
            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void SomeFalse_WhenIsInvalidInput_ReturnsTrue(params bool[] values)
        {
            //Act
            var result = Bool.SomeFalse(values);
            //Assert
            Assert.True(result);
        }
    }
}
