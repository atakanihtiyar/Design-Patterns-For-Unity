using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : SuperPower
{
    public override void Activate()
    {
        Move(10f);
        PlaySound("fireball.wav");
    }
}
