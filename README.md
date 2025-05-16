
# Naming Case Convention

### Features
- Supports 11 common case styles (see list below)  
- Allows custom case styles via `CustomNamingCase`  
- Highly configurable using `NamingOptions`  
- Extensible through `NamingExtensions`  
- Supports non-Latin characters, symbols, and more when `AsciiOnly` is set to `false`  

### Supported Case Styles

```
Tobias says Hello World

Camel:      tobiasSaysHelloWorld
Constant:   TOBIAS_SAYS_HELLO_WORLD
Dot:        tobias.says.hello.world
Flat:       tobiassayshelloworld
Kebab:      tobias-says-hello-world
Pascal:     TobiasSaysHelloWorld
Path:       Tobias/Says/Hello/World
Sentence:   Tobias says hello world
Snake:      tobias_says_hello_world
Title:      Tobias Says Hello World
Train:      Tobias-Says-Hello-World
```

### Use Cases

- Properties  
  - Example: C# property `"YourPropertyName"` → JSON `"your-property-name"`  
- Auto-generated scripts  
- Dictionaries and lookup tables  
  - Resources  
  - Styles  
  - Language files  
  - Configuration files  
  - Translations  
- Tags and labels in applications  
- Databases and table fields  
- APIs and data serialization  
- File names and paths  
- User interface elements (e.g., class or CSS names)  
- Logging and debugging outputs  
- Code generators  

### Example 1

```csharp
var example0 = "Hello World";
var example1 = "GitHub Examples";
var example2 = "Austria is a beautiful country";
var example3 = "WhatIsYourName?";
var example4 = "EverythingOK?";

var examples = new[] { example0, example1, example2, example3, example4 };

foreach (var example in examples)
{
    var str = example.ConvertNamingCase<SnakeCase>(new NamingOptions()
    {
        AsciiOnly = true,
        KeepPunctuations = false,
        KeepSymbols = false,
        IgnoreIfInvalidCharacters = true,
        SeparateIfUpperCase = true,
        KeepUpperCaseWord = true
    });

    Console.WriteLine(str);
}
```

**Output:**

```
hello_world
git_hub_examples
austria_is_a_beautiful_country
what_is_your_name
everything_ok
```

### Example 2

```csharp
var values = new List<string>();

foreach (var name in Enum.GetNames<StringComparison>())
{
    var value = name.ConvertNamingCase<SnakeCase>();
    values.Add(value);
    Console.WriteLine(value);
}

// Output:

// current_culture
// current_culture_ignore_case
// invariant_culture
// invariant_culture_ignore_case
// ordinal
// ordinal_ignore_case

foreach (var value in values)
{
    Console.WriteLine(value.ConvertNamingCase<PascalCase>());
}

// Output:

// CurrentCulture
// CurrentCultureIgnoreCase
// InvariantCulture
// InvariantCultureIgnoreCase
// Ordinal
// OrdinalIgnoreCase
```

### License

See MIT License
