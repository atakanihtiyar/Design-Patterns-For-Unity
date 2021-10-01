using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    internal class Processor : MonoBehaviour, IProduct<PersonalComputerFactory>, IProduct<MicroControllerFactory>
    {
        public float speed = 0f;

        public void Operate()
        {
            Debug.Log("Processor operating");
        }
    }
}

