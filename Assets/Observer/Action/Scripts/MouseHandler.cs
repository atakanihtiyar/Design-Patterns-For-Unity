using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer.Action
{
    internal class MouseHandler : MonoBehaviour
    {
        private void OnEnable()
        {
            Clickable.OnSomeoneClickedOnMe += OnNotify;
        }

        private void OnDisable()
        {
            Clickable.OnSomeoneClickedOnMe -= OnNotify;
        }

        private void OnNotify(GameObject obj, Vector3 mouseLocalPositionOnSubject)
        {
            Debug.Log("I am reporting as " + gameObject.name + ". Someone touched the " + mouseLocalPositionOnSubject.ToString() + " of " + obj.name + ".");
        }
    }
}
