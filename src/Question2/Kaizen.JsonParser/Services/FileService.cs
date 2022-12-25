namespace Kaizen.JsonParser.Services
{
    public interface IFileService
    {
        string Write(string content);
    }

    public class FileService : IFileService
    {
        public string Write(string content)
        {
            if(content is null)
                throw new ArgumentNullException(nameof(content));

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = Path.Combine(path, "File.txt");
            File.WriteAllText(fileName, content);

            return fileName;
        }
    }
}