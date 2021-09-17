using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer.Manual
{
    internal abstract class Subject : MonoBehaviour
    {
        private List<Observer> _observers = new List<Observer>();
        [SerializeField] private SubjectType type;
        
        public SubjectType Type => type;

        private void OnEnable()
        {
            ObserverManager.Subscribe(this);
        }

        public void Subscribe(Observer observer)
        {
            if (_observers == null)
                _observers = new List<Observer>();

            _observers.Add(observer);
        }

        public void Unsubscribe(Observer observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify(GameObject obj, Vector3 mouseLocalPosition)
        {
            _observers.ForEach(x =>
           {
               x.OnNotify(obj, mouseLocalPosition);
           });
        }
    }

    internal enum SubjectType
    {
        MousePosition
    }
}
