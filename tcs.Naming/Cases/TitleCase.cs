namespace tcs.Naming;

public sealed class TitleCase : NamingCaseBase
{
    public override string? SpecialCharacters => " ";

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, CharacterCasing.Word);
        return string.Join(" ", words);
    }
}
