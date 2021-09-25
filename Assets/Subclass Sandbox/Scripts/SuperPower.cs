using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SubclassSandbox
{
    internal abstract class SuperPower
    {
        public abstract void Activate();

        protected void Move(float speed)
        {
            Debug.Log("Speed: " + speed);
        }

        protected void PlaySound(string soundName)
        {
            Debug.Log("Playing sound: " + soundName);
        }
    }
}