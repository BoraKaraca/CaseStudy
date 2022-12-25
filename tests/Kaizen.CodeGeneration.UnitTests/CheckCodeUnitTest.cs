using Kaizen.CodeGeneration.Services;

namespace Kaizen.CodeGeneration.UnitTests
{
    public class CheckCodeUnitTest
    {
        [Theory]
        [InlineData("ACDEFGHKLMNPRTXYZ234579")]
        [InlineData("79")]
        [InlineData("87")]
        public void CheckCode_WithCharset_ExpectedEqualCharsetPattern(string charSet)
        {
            // Arrange
            var checkCodeService = new CheckCodeService();
            checkCodeService.CharSetField = charSet;
            var generatedCodeService = new GenerateCodeService();
            generatedCodeService.CharSetField = charSet;
            var generatedCode = generatedCodeService.GenerateCode();

            // Act
            var isValid = checkCodeService.CheckCodeIsValid(generatedCode);

            // Assert
            Assert.True(isValid);
        }
    }
}