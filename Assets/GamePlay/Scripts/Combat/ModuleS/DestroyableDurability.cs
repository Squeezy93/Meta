using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DestroyableDurability: IDurability
{
    private float _durability;

    public void ChangeValue(float delta)
    {
        _durability += delta;
    }

    public float GetValue()
    {
        return  _durability;
    }

    public void SetValue(float value)
    {
        _durability = value;
    }

   
}
