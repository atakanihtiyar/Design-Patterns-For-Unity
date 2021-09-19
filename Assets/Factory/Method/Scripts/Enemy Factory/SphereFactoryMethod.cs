using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FactoryMethod
{
    public class SphereFactoryMethod : FactoryMethodBase
    {
        public override IEnemy CreateEnemy()
        {
            IEnemy enemy = (new GameObject("Sphere")).AddComponent<Sphere>();
            return enemy;
        }
    }
}

