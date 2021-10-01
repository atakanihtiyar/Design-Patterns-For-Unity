using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.TypeObject
{
    internal class CanFly : IFlyingType
    {
        public bool CanIFly()
        {
            return true;
        }
    }
}

