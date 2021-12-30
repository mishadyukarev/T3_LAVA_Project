namespace Game
{
    public sealed class EnemyC : IUpdate
    {
        readonly EnemyM _enemyM;
        readonly EnemyVC _enemyVC;

        internal bool CanGetAim => _enemyM.IsDead;

        public EnemyC(in EnemyVC enemyVC)
        {
            _enemyM = new EnemyM();
            _enemyVC = enemyVC;
        }

        public void Update()
        {

        }

        internal void Kill()
        {
            _enemyM.IsDead = true;
        }
    }
}