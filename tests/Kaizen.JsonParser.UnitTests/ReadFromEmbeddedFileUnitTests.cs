using Kaizen.JsonParser.Services;

namespace Kaizen.JsonParser.UnitTests
{
    public class ReadFromEmbeddedFileUnitTests
    {
        [Fact]
        public void ReadFromEmbeddedFile_ResourceNameEqualResponseJson_IsNotNull()
        {
            // Arrange
            var readFromEmbeddedFileService = new ReadFromEmbeddedFileService();
            var resourceName = "response.json";

            // Act
            var result = readFromEmbeddedFileService.GetFromResources(resourceName);

            // Assert
            Assert.NotNull(result);
        }
    }
}