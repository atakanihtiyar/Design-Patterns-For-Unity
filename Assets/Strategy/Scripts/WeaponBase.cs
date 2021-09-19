using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Strategy
{
    internal class WeaponBase
    {
        protected int _damage = 0;
        protected IDoDamage _damageType;

        internal void TryToAttack()
        {
            _damageType?.DoDamage(_damage);
        }
    }
}

