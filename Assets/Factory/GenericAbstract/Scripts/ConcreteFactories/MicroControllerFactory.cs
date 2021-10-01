using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    internal class MicroControllerFactory : IFactory<MicroControllerFactory>
    {
        public TProductType Plug<TProductType>(GameObject gameObject) where TProductType : MonoBehaviour, IProduct<MicroControllerFactory>
        {
            Debug.Log(typeof(TProductType).Name + " assembly done");
            TProductType product = gameObject.AddComponent<TProductType>();
            return product;
        }
    }
}

