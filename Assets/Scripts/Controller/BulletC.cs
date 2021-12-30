using System;
using UnityEngine;

namespace Game
{
    public sealed class BulletC
    {
        readonly BulletVC _bulletVC;
        readonly EnemyC[] _enemyCs;

        public BulletC(in (BulletVC, EnemyC[]) controllers, out Action<Collision> action)
        {
            _bulletVC = controllers.Item1;
            _enemyCs = controllers.Item2;
            action = ExecuteCollider;
        }

        void ExecuteCollider(Collision collision)
        {
            var curPar = collision.collider.transform;

            for (var i = 0; i < 5; i++)
            {
                if (_bulletVC.TryKillEnemy(curPar, out var idxEnemy))
                {
                    _enemyCs[idxEnemy].Kill();
                    break;
                }
                else
                {
                    if (curPar.parent != default) curPar = curPar.parent;
                    else break;
                }
            }
        }

        internal void Shoot(in int strengthShoot, in Vector3 startPos, in Quaternion startRot)
        {
            _bulletVC.Shoot(strengthShoot, startPos, startRot);
        }
    }
}