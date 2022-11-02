// See https://aka.ms/new-console-template for more information

var collection = new string[] {  };
var config = new EnumeratorConfig
{
    MinLength = 3,
    MaxLength = 10,
    StartWithCapitalLetter = true
};

var enumerator = new CustomStringEnumerator.Tests.CustomStringEnumerator(collection, config);
foreach (var s in enumerator)
{
    Console.WriteLine(s);
}

Console.WriteLine("Hello, World!");