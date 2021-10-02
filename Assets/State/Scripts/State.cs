using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    /// <typeparam name="T">The owner class of the state must be entered as <typeparamref name="T"/> parameter. For example, for <c>Player</c> script and its movement states, <typeparamref name="T"/> parameter should be <c>Player</c>.</typeparam>
    public abstract class State<T>
    {
        public abstract void EnterState(T t);
        public abstract void Update(T t);
        public abstract void OnCollisionEnter(T t);
    }
}
 