namespace tcs.Naming;

public sealed class PathCase : NamingCaseBase
{
    public override string? SpecialCharacters => "/";

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, CharacterCasing.Normal);
        return string.Join("/", words);
    }
}
