using System;
using UnityEngine;

namespace Game
{
    public sealed class BulletVC
    {
        BulletV _bulletV;

        public BulletVC(in BulletV bulletV)
        {
            _bulletV = bulletV;
        }

        public void SetColliderEnterAction(in Action<Collision> action) => _bulletV.ColliderEnter.SetAction(action);

        public bool TryKillEnemy(in Transform curParent, out int idxEnemy)
        {
            idxEnemy = default;

            if (curParent.TryGetComponent(out EnemyV enemyV))
            {
                enemyV.EnabledAnim = false;
                idxEnemy = enemyV.Idx;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Shoot(in int strengthShoot, in Vector3 startPos, in Quaternion startRot)
        {
            _bulletV.gameObject.SetActive(true);

            _bulletV.transform.position = startPos;
            _bulletV.transform.rotation = startRot;

            _bulletV.Rigidbody.velocity = default;

            _bulletV.Rigidbody.AddForce(_bulletV.transform.right * strengthShoot);
        }
    }
}