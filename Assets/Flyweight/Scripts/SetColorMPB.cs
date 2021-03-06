using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Flyweight 
{
    internal class SetColorMPB : MonoBehaviour
    {
        private Renderer _renderer;
        private MaterialPropertyBlock _propBlock;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _propBlock = new MaterialPropertyBlock();
        }

        private void Update()
        {
            _renderer.GetPropertyBlock(_propBlock);
            _propBlock.SetColor("_Color", GetRandomColor());
            _renderer.SetPropertyBlock(_propBlock);
        }

        private Color GetRandomColor()
        {
            return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}

