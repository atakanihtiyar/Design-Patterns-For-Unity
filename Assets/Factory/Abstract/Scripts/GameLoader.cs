using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.AbstractFactory
{
    internal class GameLoader : MonoBehaviour
    {
        private void Start()
        {
            IAbstractFactoryBase breathableFactory = new BreathableWorldFactory();
            WorldGenerator breathableGenerator = new WorldGenerator(breathableFactory);
            breathableGenerator.Generate();

            IAbstractFactoryBase unbreathableFactory = new UnbreathableWorldFactory();
            WorldGenerator unbreathableGenerator = new WorldGenerator(unbreathableFactory);
            unbreathableGenerator.Generate();
        }
    }
}

