# Naming Case Convention 

### Features
- 11 known case kinds (see list below) 
- Custom case support `CustomNamingCase`
- Convention options `NamingOptions`
- Extension support `NamingExtensions`
- Designation using non-Latin characters, symbols, etc... also possible (if Ascii is false)

### Support Naming Cases

```
Tobias says Hello World

Camel:		tobiasSaysHelloWorld
Constant:	TOBIAS_SAYS_HELLO_WORLD
Dot:		tobias.says.hello.world
Flat:		tobiassayshelloworld
Kebab:		tobias-says-hello-world
Pascal:		TobiasSaysHelloWorld
Path:		Tobias/Says/Hello/World
Sentence:	Tobias says hello world
Snake:		tobias_says_hello_world
Title:		Tobias Says Hello World
Train:		Tobias-Says-Hello-World
```

### Uses

- Properties
    - Example C# to JSON: "YourPropertyName" -> "your-property-name"
- Autogenerate scripts
- Dictionaries
  - Resources
  - Styles
  - Languages
  - ...
- Tags
- Databases
- ...

### Example 1
```
var example0 = "Hello World";
var example1 = "GitHub Examples";
var example2 = "Österreich ist ein schönes Land";
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

// Output:

// hello_world
// git_hub_examples
// sterreich_ist_ein_schnes_land
// what_is_your_name
// everything_ok
```

### Example 2
```
var values = new List<string>();

foreach (var name in Enum.GetNames<StringComparison>())
{
    var value = name.ConvertNamingCase<SnakeCase>();
    values.Add(value);
    Console.WriteLine(value);
}

// Outputs:

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

// Outputs:

// CurrentCulture
// CurrentCultureIgnoreCase
// InvariantCulture
// InvariantCultureIgnoreCase
// Ordinal
// OrdinalIgnoreCase
```

### License
See MIT License
