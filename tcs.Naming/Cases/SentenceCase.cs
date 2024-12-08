namespace tcs.Naming;

public sealed class SentenceCase : NamingCaseBase
{
    public override string? SpecialCharacters => " ";

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, (i) => i == 0 ? CharacterCasing.Word : CharacterCasing.Lower);
        return string.Join("", words);
    }
}
