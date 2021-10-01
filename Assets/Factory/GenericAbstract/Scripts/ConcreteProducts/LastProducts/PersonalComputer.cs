using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    internal class PersonalComputer : MonoBehaviour, IProduct<PersonalComputerFactory>
    {
        public Ram ram;
        public Processor processor;
        public Monitor monitor;

        public void Operate()
        {
            Debug.Log("Computer operating");
        }
    }
}

