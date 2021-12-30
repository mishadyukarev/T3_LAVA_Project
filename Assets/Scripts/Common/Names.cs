using UnityEditor;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Names", menuName = "ScriptableObjects/Names")]
    public sealed class Names : ScriptableObject
    {
        string _enemyTag = "Enemy";

        public const string CROUCHED_NAME_IN_ANIMATOR = "IsCrouched";
        public const string BLEND_NAME_IN_ANIMATOR = "Blend";

        public string EnemyTag => _enemyTag;
    }
}