using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SubclassSandbox
{
    internal class Fireball : SuperPower
    {
        public override void Activate()
        {
            Move(10f);
            PlaySound("fireball.wav");
        }
    }
}
