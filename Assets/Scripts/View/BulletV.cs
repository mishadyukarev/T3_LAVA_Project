using UnityEditor;
using UnityEngine;

namespace Game
{
    public sealed class BulletV : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }
        public ColliderEnter ColliderEnter { get; private set; }

        void OnEnable()
        {
            Rigidbody = GetComponent<Rigidbody>();
            ColliderEnter = GetComponent<ColliderEnter>();
        }
    }
}