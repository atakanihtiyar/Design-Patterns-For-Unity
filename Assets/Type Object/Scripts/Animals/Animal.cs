using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.TypeObject
{
    internal abstract class Animal
    {
        protected string _name;
        protected IFlyingType _canFly;

        public Animal(string name, bool canFly)
        {
            _name = name;
            _canFly = canFly ? new CanFly() as IFlyingType : new CantFly() as IFlyingType;
        }

        public abstract void Talk();
    }
}

