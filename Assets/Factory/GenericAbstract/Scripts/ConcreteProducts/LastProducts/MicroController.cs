using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    internal class MicroController : MonoBehaviour, IProduct<MicroControllerFactory>
    {
        public Ram ram;
        public Processor processor;

        public void Operate()
        {
            Debug.Log("MicroController operating");
        }
    }
}

