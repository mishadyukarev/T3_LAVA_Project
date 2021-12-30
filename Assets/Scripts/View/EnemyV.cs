using UnityEngine;

namespace Game
{
    public sealed class EnemyV : UnitV
    {
        public int Idx;

        [SerializeField] public Rigidbody[] Rigidbodies { get; private set; }
    }
}