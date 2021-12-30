using System;
using UnityEngine;

namespace Game
{
    public sealed class ColliderEnter : MonoBehaviour
    {
        Action<Collision> _action;
        public void SetAction(Action<Collision> action) => _action = action;
        void OnCollisionEnter(Collision collision) => _action?.Invoke(collision);
    }
}