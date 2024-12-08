namespace tcs.Naming;

public sealed class ConstantCase : NamingCaseBase
{
    public override string? SpecialCharacters => "_";

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, CharacterCasing.Upper);
        return string.Join("_", words);
    }
}
