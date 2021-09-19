using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FactoryMethod
{
    public class EnemySpawner : MonoBehaviour
    {
        void Start()
        {
            SphereFactoryMethod sphereFactory = new SphereFactoryMethod();
            IEnemy sphere = sphereFactory.GetEnemy();

            CubeFactoryMethod cubeFactory = new CubeFactoryMethod();
            IEnemy cube = cubeFactory.GetEnemy();
        }
    }
}

