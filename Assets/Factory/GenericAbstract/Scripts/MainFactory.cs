using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    public class MainFactory<TFactoryType> where TFactoryType : IFactory<TFactoryType>
    {
        public TProductType Assemble<TProductType>(GameObject gameObject) where TProductType : MonoBehaviour, IProduct<TFactoryType>
        {
            Debug.Log(typeof(TProductType).Name + " assembly done");
            TProductType product = gameObject.AddComponent<TProductType>();
            return product;
        }
    }
}

