using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal class Hydrogen : ISky
    {
        public void Waiting()
        {
            Debug.Log("Hydrogen waiting to be fuel ...");
        }
    }
}

