namespace Game
{
    public readonly struct VCPool
    {
        public readonly CameraVC CameraVC;
        public readonly PlayerVC PlayerVC;
        public readonly PlayerAnimationVC PlayerAnimVC;
        public readonly EnemyVC[] EnemyVCs;
        public readonly BulletVC[] BulletVC;

        public VCPool(in VPool vPool, in Resources resources)
        {
            CameraVC = new CameraVC(vPool.CameraV, resources.StartValues);

            PlayerVC = new PlayerVC(vPool.PlayerV, resources.StartValues, resources.Names);
            PlayerAnimVC = new PlayerAnimationVC(vPool.PlayerV);

            EnemyVCs = new EnemyVC[vPool.EnemyVs.Length];
            for (var i = 0; i < vPool.EnemyVs.Length; i++) EnemyVCs[i] = new EnemyVC(vPool.EnemyVs[i]);

            BulletVC = new BulletVC[vPool.BulletVs.Length];
            for (var i = 0; i < BulletVC.Length; i++) BulletVC[i] = new BulletVC(vPool.BulletVs[i]);
        }
    }
}