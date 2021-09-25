using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.TypeObject
{
    internal class Fish : Animal
    {
        public Fish(string name, bool canFly) : base(name, canFly)
        {

        }

        public override void Talk()
        {
            string canFlyString = _canFly.CanIFly() ? "can" : "can't";

            Debug.Log($"Hello, my name is {_name} and i am a fish. I {canFlyString} fly.");
        }
    }
}

