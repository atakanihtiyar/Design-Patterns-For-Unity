using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.TypeObject
{
    internal class CantFly : IFlyingType
    {
        public bool CanIFly()
        {
            return false;
        }
    }
}

