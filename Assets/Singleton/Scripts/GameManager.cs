using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Singleton
{
    internal class GameManager : SingletonBehaviour<GameManager>
    {
        internal string playerName = "El presidente";
    }
}
