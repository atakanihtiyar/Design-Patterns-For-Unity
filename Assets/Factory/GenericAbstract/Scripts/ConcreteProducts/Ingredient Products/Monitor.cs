using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    internal class Monitor : MonoBehaviour, IProduct<PersonalComputerFactory>
    {
        public int size = 0;

        public void Operate()
        {
            Debug.Log("Monitor operating");
        }
    }
}

