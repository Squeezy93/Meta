using System.Collections.Generic;

public interface IModule
{
    string Id { get; }
    string Name { get; }
    string Description { get; }
    string Type { get; }
    List<Attribute> Attributes { get; }
    IDurability Durability { get; }
    string GetAttributesToString();
}
