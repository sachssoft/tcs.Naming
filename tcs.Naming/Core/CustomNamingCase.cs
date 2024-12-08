using System;

namespace tcs.Naming;

public class CustomNamingCase : NamingCaseBase
{
    public CustomNamingCase(string? special_characters, string? separator, Func<int, CharacterCasing> casing_action)
    {
        SpecialCharacters = special_characters;
        Separator = separator;
        CasingAction = casing_action;
    }

    public Func<int, CharacterCasing> CasingAction { get; }

    public override string? SpecialCharacters { get; }

    public string? Separator { get; }

    public override string ConvertTo(string value, NamingOptions options)
    {
        var words = GetWords(value, options, CasingAction);
        return string.Join(Separator, words);
    }
}
