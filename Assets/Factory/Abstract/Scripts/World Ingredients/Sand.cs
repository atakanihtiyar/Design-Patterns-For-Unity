using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal class Sand : IEarth
    {
        public void Ready()
        {
            Debug.Log("The sand is ready to become glass.");
        }
    }
}

