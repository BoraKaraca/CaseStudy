using Kaizen.JsonParser.Services;

namespace Kaizen.JsonParser.UnitTests
{
    public class FileUnitTests
    {
        [Fact]
        public void File_ContentIsNull_ThrowNullException()
        {
            // Arrange
            var fileService = new FileService();
            const string content = null;

            // Act
            Action action = () => fileService.Write(content);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}