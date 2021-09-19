using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal class Oxygen : ISky
    {
        public void Waiting()
        {
            Debug.Log("Oxygen waiting to be breathed...");
        }
    }
}

