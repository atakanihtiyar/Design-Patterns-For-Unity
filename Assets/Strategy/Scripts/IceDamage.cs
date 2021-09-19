using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Strategy
{
    internal class IceDamage : IDoDamage
    {
        public void DoDamage(int damage)
        {
            Debug.Log("Ice damage: " + damage);
        }
    }
}

