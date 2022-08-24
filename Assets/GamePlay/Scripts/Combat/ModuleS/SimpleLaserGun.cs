using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SimpleLaserGun : IModule
{
    public string Id => "SimpleLaserGun";

    public string Name => "Simple Laser Gun";

    public string Description => "Laser Gun, shoot faster end endless bullet";

    public string Type => "SimpleLaserGunType";

    private List<Attribute> _attributes = new List<Attribute>();
    public List<Attribute> Attributes => _attributes;

    private IDurability _durability = new DestroyableDurability();
    public IDurability Durability => _durability;

    public string GetAttributesToString()
    {
        return String.Join("\n", _attributes.Select(x => $"{x.Name}: {x.Value}"));
    }
}
