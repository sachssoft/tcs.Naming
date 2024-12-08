namespace tcs.Naming;

public sealed class FlatCase : NamingCaseBase
{
    public override string? SpecialCharacters => null;

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, CharacterCasing.Lower);
        return string.Join("", words);
    }
}
