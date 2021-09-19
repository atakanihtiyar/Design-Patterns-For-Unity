using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FactoryMethod
{
    public class CubeFactoryMethod : FactoryMethodBase
    {
        public override IEnemy CreateEnemy()
        {
            IEnemy enemy = (new GameObject("Cube")).AddComponent<Cube>();
            return enemy;
        }
    }
}

