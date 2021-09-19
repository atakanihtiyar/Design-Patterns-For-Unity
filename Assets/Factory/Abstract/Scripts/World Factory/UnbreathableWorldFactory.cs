using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal class UnbreathableWorldFactory : IAbstractFactoryBase
    {
        public IEarth GetEarth()
        {
            return new Sand();
        }

        public ISky GetSky()
        {
            return new Hydrogen();
        }
    }
}

