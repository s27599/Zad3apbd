// See https://aka.ms/new-console-template for more information

using Zad3.Models;
using Zad3.Models.@base;

Console.WriteLine("Hello, World!");


RefrigeratedContainer container = new RefrigeratedContainer(12,14,54,211);
container.Temp = 20;
container.Load(12,Products.Bananas);
Console.Out.WriteLine(container.Loaded+" "+ container.Products);
container.Load(12,Products.Butter);
container.Temp = 12;
