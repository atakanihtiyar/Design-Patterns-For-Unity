using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    public interface IFactory<TFactoryType>
    {
        TProductType Plug<TProductType>(GameObject gameObject) where TProductType : MonoBehaviour, IProduct<TFactoryType>;
    }
}
