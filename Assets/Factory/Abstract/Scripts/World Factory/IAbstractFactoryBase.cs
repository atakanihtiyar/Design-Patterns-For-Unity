using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal interface IAbstractFactoryBase
    {
        ISky GetSky();
        IEarth GetEarth();
    }
}

