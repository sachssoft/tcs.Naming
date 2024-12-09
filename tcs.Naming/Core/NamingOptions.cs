using System.Globalization;

namespace tcs.Naming;

public class NamingOptions
{
    public CultureInfo? Culture { get; set; }

    public bool AsciiOnly { get; set; }

    public bool KeepSymbols { get; set; }

    public bool KeepPunctuations { get; set; }

    public bool IgnoreIfInvalidCharacters { get; set; }

    public bool SeparateIfUpperCase { get; set; } 

    public bool KeepUpperCaseWord { get; set; }
}
