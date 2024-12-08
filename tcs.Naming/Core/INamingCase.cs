namespace tcs.Naming;

public interface INamingCase
{
    string ConvertTo(string value, NamingOptions options);

    string? SpecialCharacters { get; }
}
