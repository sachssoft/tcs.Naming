using System;
using System.Collections.Generic;
using System.Globalization;

namespace tcs.Naming;

public abstract class NamingCaseBase : INamingCase
{
    internal protected NamingCaseBase()
    {
    }

    // Wandle den Namen durch die String-Case-Transformation um.
    public abstract string ConvertTo(string value, NamingOptions options);

    // Spezielle Zeichen sind Teil der String-Case
    public abstract string? SpecialCharacters { get; }

    // Finde die Wörter aus diesem Wert heraus
    internal protected string[] GetWords(string? value, NamingOptions options, CharacterCasing casing)
        => GetWords(value, options, (i) => casing);

    // Finde die Wörter aus diesem Wert heraus
    internal protected string[] GetWords(string? value, NamingOptions options, Func<int, CharacterCasing> casing_action)
    {
        if (string.IsNullOrWhiteSpace(value)) return new string[0];

        var words = new List<string>();
        var current_word = string.Empty;

        for (int i = 0; i < value.Length; i++)
        {
            var current = value[i];

            if (!KeepCharacter(current, SpecialCharacters, options, false)) continue;

            // Füge ein Zeichen hinzu
            current_word += current;

            // Weiter mit der Prüfung eines nächsten Zeichen
            if (i < value.Length - 1)
            {
                var next = value[i + 1];
                var condition = !KeepCharacter(next, SpecialCharacters, options, true);

                // Prüfe, ob dieses Zeichen klein ist
                if (char.IsLower(current))
                {
                    var should_separate = false;

                    if (char.IsUpper(next))
                    {
                        should_separate = options.SeparateIfUpperCase;
                    }

                    condition |= should_separate;
                }
                // Prüfe, ob dieses Zeichen groß ist
                else if (char.IsUpper(current))
                {
                    if (char.IsUpper(next))
                    {
                        condition |= !options.KeepUpperCaseWord;
                    }
                }

                // Wenn es eine Zeichensetzung oder ein Leerzeichen ist
                if (condition && current_word.Length > 0)
                {
                    words.Add(TransformCase(current_word, options, casing_action(words.Count)));
                    current_word = string.Empty;
                }
            }
            else if (i == value.Length - 1)
            {
                words.Add(TransformCase(current_word, options, casing_action(words.Count)));
            }
        }

        return words.ToArray();
    }

    private string TransformCase(string word, NamingOptions options, CharacterCasing casing)
    {
        var culture = options.Culture ?? CultureInfo.InvariantCulture;

        switch (casing)
        {
            case CharacterCasing.Lower:
                return culture.TextInfo.ToLower(word);
            case CharacterCasing.Upper:
                return culture.TextInfo.ToUpper(word);
            case CharacterCasing.Word:
                return culture.TextInfo.ToTitleCase(word);
            default:
                return word;
        }
    }

    private bool KeepCharacter(char character, string? special_chars, NamingOptions options, bool ignore_condition)
    {
        // Ist es eine Zeichensetzung oder ein Leerzeichen?
        if (char.IsWhiteSpace(character)) return false;

        // Ist es ein Trennzeichen?
        if (char.IsSeparator(character)) return false;

        // Ist es ein Spezialzeichen?
        if (special_chars != null && special_chars.Contains(character)) return false;

        // Setze die Kondition beim Ignorieren der Zeichensetzung
        var result = ignore_condition && options.IgnoreIfInvalidCharacters;

        // Option: Ist es ein Teil von Ascii?
        if (options.AsciiOnly && !char.IsAscii(character)) return result;

        // Option: Werden die Zeichensetzungen behalten?
        if (!options.KeepPunctuations && char.IsPunctuation(character)) return false;

        // Option: Werden die Symbole behalten?
        if (!options.KeepSymbols && char.IsSymbol(character)) return result;

        return true;
    }
}
