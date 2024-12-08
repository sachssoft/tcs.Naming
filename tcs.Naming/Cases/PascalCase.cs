namespace tcs.Naming;

public sealed class PascalCase : NamingCaseBase
{
    public override string? SpecialCharacters => null;

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, CharacterCasing.Word);
        return string.Join("", words);
    }
}
