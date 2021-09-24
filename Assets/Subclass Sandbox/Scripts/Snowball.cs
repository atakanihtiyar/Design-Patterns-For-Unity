using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : SuperPower
{
    public override void Activate()
    {
        Move(5f);
        PlaySound("snowball.wav");
    }
}
