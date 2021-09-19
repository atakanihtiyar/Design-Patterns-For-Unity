using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal class Dirt : IEarth
    {
        public void Ready()
        {
            Debug.Log("The dirt is ready for anything.");
        }
    }
}

