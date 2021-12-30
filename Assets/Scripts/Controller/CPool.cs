using System.Collections.Generic;

namespace Game
{
    public struct CPool : IUpdate
    {
        List<IUpdate> _updates;

        public CPool(in VCPool vCPool)
        {
            _updates = new List<IUpdate>();

            var cameraC = new CameraC(vCPool);
            _updates.Add(cameraC);

            var enemyCs = new EnemyC[vCPool.EnemyVCs.Length];
            for (var i = 0; i < enemyCs.Length; i++)
            {
                enemyCs[i] = new EnemyC(vCPool.EnemyVCs[i]);
                _updates.Add(enemyCs[i]);
            }

            var bulletCs = new BulletC[vCPool.BulletVC.Length];
            for (var i = 0; i < bulletCs.Length; i++)
            {
                bulletCs[i] = new BulletC((vCPool.BulletVC[i], enemyCs), out var action);
                vCPool.BulletVC[i].SetColliderEnterAction(action);
            }

            var playerC = new PlayerC(vCPool, (enemyCs, bulletCs));
            _updates.Add(playerC);

            var inputC = new InputC(playerC);
            _updates.Add(inputC);
        }

        public void Update() => _updates.ForEach((IUpdate upd) => upd.Update());
    }
}