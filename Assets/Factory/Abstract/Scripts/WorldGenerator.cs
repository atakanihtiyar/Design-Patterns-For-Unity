using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal class WorldGenerator
    {
        private IAbstractFactoryBase _worldType;

        public WorldGenerator(IAbstractFactoryBase worldType)
        {
            _worldType = worldType;
        }

        public void Generate()
        {
            ISky sky = _worldType.GetSky();
            sky.Waiting();

            IEarth earth = _worldType.GetEarth();
            earth.Ready();
        }
    }
}

