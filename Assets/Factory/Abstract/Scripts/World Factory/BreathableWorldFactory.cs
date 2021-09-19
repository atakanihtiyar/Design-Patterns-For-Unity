using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal class BreathableWorldFactory : IAbstractFactoryBase
    {
        public IEarth GetEarth()
        {
            return new Dirt();
        }

        public ISky GetSky()
        {
            return new Oxygen();
        }
    }
}

