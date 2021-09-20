using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    internal class PersonalComputerFactory : IFactory<PersonalComputerFactory>
    {
        public TProductType Plug<TProductType>(GameObject gameObject) where TProductType : MonoBehaviour, IProduct<PersonalComputerFactory>
        {
            Debug.Log(typeof(TProductType).Name + " assembly done");
            TProductType product = gameObject.AddComponent<TProductType>();
            return product;
        }
    }
}

