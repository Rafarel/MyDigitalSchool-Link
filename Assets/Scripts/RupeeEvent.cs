using System;
using UnityEngine;

public class RupeeEvent : EventArgs
{
    public RupeeEvent(Rupee rupee)
    {
        Rupee = rupee;
    }

    public Rupee Rupee { get; private set; }
}