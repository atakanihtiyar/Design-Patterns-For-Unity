using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer.Manual
{
    internal class MouseHandler : Observer
    {
        private void OnEnable()
        {
            ObserverManager.Subscribe(this, SubjectType.MousePosition);
        }

        public override void OnNotify(GameObject obj, Vector3 mouseLocalPositionOnSubject)
        {
            Debug.Log("I am reporting as " + gameObject.name + ". Someone touched the " + mouseLocalPositionOnSubject.ToString() + " of " + obj.name + ".");
        }
    }
}

