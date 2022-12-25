using Kaizen.CodeGeneration.Services;
using System.Text.RegularExpressions;

namespace Kaizen.CodeGeneration.UnitTests;

public class GenerateCodeUnitTest
{
    [Fact]
    public void GenerateCode_WithDefaultCharset_Expected8DigitLength()
    {
        // Arrange
        var generateCodeService = new GenerateCodeService();
        var generatedCode = generateCodeService.GenerateCode();

        // Act
        var generatedCodeLenght = generatedCode.Length;

        // Assert
        Assert.Equal(8, generatedCodeLenght);
    }

    [Theory]
    [InlineData("AAC")]
    [InlineData("AAA")]
    [InlineData("E2XQ")]
    public void GenerateCode_WithCharset_ExpectedEqualCharsetPatternWithRegex(string charSet)
    {
        // Arrange
        var generatedCodeService = new GenerateCodeService();
        generatedCodeService.CharSetField = charSet;
        var generatedCode=generatedCodeService.GenerateCode();

        // Act
        bool patternIsValid = Regex.IsMatch(generatedCode, "^[" + charSet + "]+$");

        // Assert
        Assert.True(patternIsValid);
    }
}