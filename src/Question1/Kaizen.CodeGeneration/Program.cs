using Kaizen.CodeGeneration.Services;

static IServiceProvider ServiceRegistration()
{
    return new ServiceCollection()
               .AddScoped<IGenerateCodeService, GenerateCodeService>()
               .AddScoped<ICheckCodeService, CheckCodeService>()
               .BuildServiceProvider();
}

Execute();

static void Execute()
{
    DisplayOptionFollowingList();

    var selectedOption = GetSelectedOption();

    ProcessForSelected(selectedOption);

    Execute();
}

static void ProcessForSelected(ConsoleKeyInfo selectedOption)
{
    var serviceProvider = ServiceRegistration();

    switch (selectedOption.Key)
    {
        case ConsoleKey.G:
            Console.WriteLine($"{Environment.NewLine}Generating code");
            Console.WriteLine(new string('-', 8));
            GenerateCodes(serviceProvider);
            Console.WriteLine(new string('-', 8));
            Console.WriteLine("Generating code is done.");
            break;

        case ConsoleKey.C:
            CheckIsCodeValid(serviceProvider);
            break;

        case ConsoleKey.Escape:
        case ConsoleKey.E:
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine(@$"{Environment.NewLine}This value you entered '{selectedOption.Key}' isn't in the list.
                                 {Environment.NewLine}Please choose one of the options in the list!");
            Execute();
            break;
    }

    static void CheckIsCodeValid(IServiceProvider serviceProvider)
    {
        Console.WriteLine($"{Environment.NewLine} Please enter the code you want to check");
        var enteredCode = Console.ReadLine();
        var enteredCodeIsValid = CheckCodeServiceProvider(serviceProvider, enteredCode!);
        if (!enteredCodeIsValid)
        {
            Console.WriteLine($"'{enteredCode}' your code is not valid!");
            return;
        }

        Console.WriteLine($"'{enteredCode}' your code is valid.");
    }

    static void GenerateCodes(IServiceProvider serviceProvider)
    {
        for (var i = 0; i < 1000; i++)
        {
            GenerateCode(serviceProvider);
        }
    }

    static void GenerateCode(IServiceProvider serviceProvider)
    {
        var generatedCode = GenerateCodeServiceProvider(serviceProvider);
        Console.WriteLine($"{generatedCode}");
    }
}

static ConsoleKeyInfo GetSelectedOption()
{
    Console.Write("Your option? ");
    var selectedOption = Console.ReadKey(true);
    return selectedOption;
}

static void DisplayOptionFollowingList()
{
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\tg - Generate Code");
    Console.WriteLine("\tc - Check Code (Just Check Charset or 8 Digit Charater)");
    Console.WriteLine("\te - Exit ");
}
static bool CheckCodeServiceProvider(IServiceProvider serviceProvider, string code)
{
    var checkCodeService = serviceProvider.GetRequiredService<ICheckCodeService>();
    return checkCodeService.CheckCodeIsValid(code);
}

static string GenerateCodeServiceProvider(IServiceProvider serviceProvider)
{
    var generateCodeService = serviceProvider.GetRequiredService<IGenerateCodeService>();
    return generateCodeService.GenerateCode();
}