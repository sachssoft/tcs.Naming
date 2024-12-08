namespace tcs.Naming;

public sealed class CamelCase : NamingCaseBase
{
    public override string? SpecialCharacters => null;

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, (i) => i == 0 ? CharacterCasing.Lower : CharacterCasing.Word);
        return string.Join("", words);
    }
}
