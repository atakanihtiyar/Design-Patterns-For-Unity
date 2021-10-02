using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer.Manual
{
    internal class ObserverManager : MonoBehaviour
    {
        private static List<Subject> _subjects = new List<Subject>();

        public static void Add(Subject subject)
        {
            if (_subjects == null)
                _subjects = new List<Subject>();

            _subjects.Add(subject);
        }

        public static void Remove(Subject subject)
        {
            _subjects.Remove(subject);
        }

        public static void Subscribe(Observer observer, SubjectType subjectType)
        {
            _subjects.ForEach( subject => 
            { 
                if (subject.Type == subjectType)
                {
                    subject.Subscribe(observer);
                }
            });
        }

        public static void Unsubscribe(Observer observer, SubjectType subjectType)
        {
            _subjects.ForEach(subject =>
            {
                if (subject.Type == subjectType)
                {
                    subject.Unsubscribe(observer);
                }
            });
        }
    }
}
