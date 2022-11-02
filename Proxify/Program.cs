// See https://aka.ms/new-console-template for more information

using CustomCollection.Tests;

var map = new StringMap<string>();
      
map.AddElement("Name", "Bernard White");
map.AddElement("Age", null);
map.AddElement("Email", "danquahwhite@gmail.com");
map.AddElement("Phone", "0240313771");


      
Console.WriteLine($"Name: {map.GetValue("Name")}");
Console.WriteLine($"Count: {map.Count.ToString()}");
Console.WriteLine($"Default Value: {map.DefaultValue}");

Console.ReadLine();