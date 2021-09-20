using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    internal class Ram : MonoBehaviour, IProduct<PersonalComputerFactory>, IProduct<MicroControllerFactory>
    {
        public int capacity = 0;

        public void Operate()
        {
            Debug.Log("Ram operating");
        }
    }
}

