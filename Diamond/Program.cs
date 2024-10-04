using System.Text;
var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
GetInput();

void GetInput()
{
    Console.WriteLine("Type a character to see its diamond representation. Or press 'Enter' to quit.");
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.Enter)
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
    
    RenderDiamond(key);
}

void RenderDiamond(ConsoleKeyInfo keyInfo)
{
    // format the input character to uppercase
    var inputCharacter = keyInfo.KeyChar.ToString().ToUpper();
    
    // validation the input data against the legal characters
    if (!alphabet.Contains(inputCharacter))
    {
        Console.WriteLine($"{Environment.NewLine}Only alpha characters are allowed. Please try again with a letter in range A-Z.{Environment.NewLine}");
        GetInput();
    }
    
    // get the character index
    var characterIndex = alphabet.IndexOf(inputCharacter, StringComparison.Ordinal);

    Console.WriteLine(); // add a line break for better readability
    
    var diamond = new StringBuilder();
    // build the diamond upper half
    for (int i = 0; i <= characterIndex; i++)
    {
        diamond.Append(new string(' ', characterIndex - i));
        diamond.Append(alphabet[i]);
        if (i > 0)
        {
            diamond.Append(new string(' ', 2 * i - 1));
            diamond.Append(alphabet[i]);
        }
        diamond.Append(Environment.NewLine);
    }

    // build the diamond lower half
    for (int i = characterIndex - 1; i >= 0; i--)
    {
        diamond.Append(new string(' ', characterIndex - i));
        diamond.Append(alphabet[i]);
        if (i > 0)
        {
            diamond.Append(new string(' ', 2 * i - 1));
            diamond.Append(alphabet[i]);
        }
        diamond.Append(Environment.NewLine);
    }

    // write to output
    Console.WriteLine(diamond);
    
    // prompt for another input
    GetInput();
}