using UnityEditor;
using UnityEngine;

namespace Game
{
    public sealed class EnemyVC
    {
        EnemyV _enemyV;


        public Vector3 Pos => _enemyV.transform.position;

        public EnemyVC(in EnemyV enemyV)
        {
            _enemyV = enemyV;
        }
    }
}