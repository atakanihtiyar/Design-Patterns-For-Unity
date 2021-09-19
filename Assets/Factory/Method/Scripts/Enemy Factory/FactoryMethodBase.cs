using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FactoryMethod
{
    public abstract class FactoryMethodBase
    {
        public IEnemy GetEnemy()
        {
            IEnemy enemy = CreateEnemy();
            enemy.Walk();

            return enemy;
        }

        public abstract IEnemy CreateEnemy();
    }
}

