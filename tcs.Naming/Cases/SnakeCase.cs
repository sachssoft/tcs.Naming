namespace tcs.Naming;

public sealed class SnakeCase : NamingCaseBase
{
    public override string? SpecialCharacters => "_";

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, CharacterCasing.Lower);
        return string.Join("_", words);
    }
}
