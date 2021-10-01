using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SubclassSandbox
{
    internal class Snowball : SuperPower
    {
        public override void Activate()
        {
            Move(5f);
            PlaySound("snowball.wav");
        }
    }
}