using System.Reflection;

namespace Kaizen.JsonParser.Services
{
    public interface IReadFromEmbeddedFileService
    {
        string GetFromResources(string resourceName);
    }

    public class ReadFromEmbeddedFileService : IReadFromEmbeddedFileService
    {
        public string GetFromResources(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(assembly.GetName().Name + '.' + resourceName);
            using var reader = new StreamReader(stream!);
            return reader.ReadToEnd();
        }
    }
}