using System;

namespace tcs.Naming;

public static class NamingExtensions
{
    public static string ConvertNamingCase<TNamingCase>(this string value) where TNamingCase : class, INamingCase, new()
        => ConvertNamingCase<TNamingCase>(value, new NamingOptions());

    public static string ConvertNamingCase<TNamingCase>(this string value, NamingOptions options) where TNamingCase : class, INamingCase, new()
    {
        var naming = new TNamingCase();
        return naming.ConvertTo(value, options);
    }

    public static string ConvertCustomNamingCase(this string value, NamingOptions options, string? separator, CharacterCasing casing)
        => ConvertCustomNamingCase(value, options, null, separator, (i) => casing);

    public static string ConvertCustomNamingCase(this string value, NamingOptions options, string? special_chars, string? separator, CharacterCasing casing)
        => ConvertCustomNamingCase(value, options, special_chars, separator, (i) => casing);

    public static string ConvertCustomNamingCase(this string value, NamingOptions options, string? separator, Func<int, CharacterCasing> casing_action)
        => ConvertCustomNamingCase(value, options, null, separator, casing_action);

    public static string ConvertCustomNamingCase(this string value, NamingOptions options, string? special_chars, string? separator, Func<int, CharacterCasing> casing_action)
    {
        var naming = new CustomNamingCase(special_chars, separator, casing_action);
        return naming.ConvertTo(value, options);
    }
}
