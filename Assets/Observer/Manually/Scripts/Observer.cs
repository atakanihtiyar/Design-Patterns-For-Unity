using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer.Manual
{
    internal abstract class Observer : MonoBehaviour
    {
        public abstract void OnNotify(GameObject obj, Vector3 mouseLocalPositionOnSubject);
    }
}
