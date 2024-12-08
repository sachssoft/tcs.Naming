# Naming 
Naming Case Conversion

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

### Usages

- Properties
    - Example C# to JSON: "YourPropertyName" -> "your-property-name"
- Autogenerate scripts
- Dictionaries
- Tags
- Databases
- ...

### Examples
```
var example0 = "Hello World";
var example1 = "GitHub Examples";
var example2 = "Österreich ist ein schönes Land";

var examples = new[] { example0, example1, example2 };

foreach (var example in examples)
{
    var str = example.ConvertNamingCase<CamelCase>(new NamingOptions()
    {
        AsciiOnly = true,
        KeepPunctuations = false,
        KeepSymbols = false,
        IgnoreIfInvalidCharacters = true
    });

    Console.WriteLine(str);
}

// Output:

// helloWorld
// githubExamples
// sterreichIstEinSchnesLand
```
