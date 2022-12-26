static IServiceProvider ServiceRegistration()
{
    return new ServiceCollection()
               .AddSingleton<IReadFromEmbeddedFileService, ReadFromEmbeddedFileService>()
               .AddScoped<IStringBuilderService, StringBuilderService>()
               .AddScoped<IFileService, FileService>()
               .BuildServiceProvider();
}

Execute();
Console.ReadKey(true);

static void Execute()
{
    var serviceProvider = ServiceRegistration();

    var jsonFile = ReadFromEmbeddedFileServiceProvider(serviceProvider, "response.json");

    var jsonModelFromSerializer = JsonSerializer.Deserialize<List<JsonModel>>(jsonFile);

    var stringBuilder = StringBuilderServiceProvider(serviceProvider, jsonModelFromSerializer);

    var createdFilePath = FileServiceProvider(serviceProvider, stringBuilder);
    Console.WriteLine($"Please check this path for txt file.{Environment.NewLine}{createdFilePath}");
}

static string ReadFromEmbeddedFileServiceProvider(IServiceProvider serviceProvider, string resourceName)
{
    var readFromEmbededFileService = serviceProvider.GetRequiredService<IReadFromEmbeddedFileService>();
    return readFromEmbededFileService.GetFromResources(resourceName);
}

static string StringBuilderServiceProvider(IServiceProvider serviceProvider, List<JsonModel> jsonModelFromSerializer)
{
    var stringBuilderService = serviceProvider.GetRequiredService<IStringBuilderService>();
    return stringBuilderService.CreateStringBuilderForJsonModel(jsonModelFromSerializer);
}
static string FileServiceProvider(IServiceProvider serviceProvider, string content)
{
    var fileService = serviceProvider.GetRequiredService<IFileService>();
    return fileService.Write(content);
}