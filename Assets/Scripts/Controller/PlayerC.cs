using UnityEngine;

namespace Game
{
    public sealed class PlayerC : IUpdate
    {
        readonly PlayerM _playerM;

        readonly EnemyC[] _enemyCs;
        readonly BulletC[] _bulletCs;

        readonly PlayerVC _playerVC;
        readonly PlayerAnimationVC _playerAnimVC;
        readonly EnemyVC[] _enemyVCs;
        readonly CameraVC _cameraVC;

        public PlayerC(in VCPool vCPool, in(EnemyC[], BulletC[]) controllers)
        {
            _playerM = new PlayerM();

            _playerAnimVC = vCPool.PlayerAnimVC;
            _playerVC = vCPool.PlayerVC;
            _enemyVCs = vCPool.EnemyVCs;
            _cameraVC = vCPool.CameraVC;

            _enemyCs = controllers.Item1; 
            _bulletCs = controllers.Item2;
        }

        public void Update()
        {
            EnemyVC minDistEnemyVC = default;

            for (var i = 0; i < _enemyVCs.Length; i++)
            {
                if (!_enemyCs[i].CanGetAim)
                {
                    if (minDistEnemyVC == default) minDistEnemyVC = _enemyVCs[i];

                    var dist_0 = minDistEnemyVC.Pos - _playerVC.Pos;
                    var dist_1 = _enemyVCs[i].Pos - _playerVC.Pos;

                    if (dist_0.magnitude > dist_1.magnitude)
                    {
                        minDistEnemyVC = _enemyVCs[i];
                    }
                }
            }

            if(minDistEnemyVC != default) _playerM.CurAimPos = minDistEnemyVC.Pos;


            if (_playerVC.TrySeeEnemy(_playerM.IsCrouched, _playerM.CurAimPos, ref _playerM.HightAim))
            {
                _playerVC.ExecuteSeen(_playerM.SpeedReadyShoot, out var haveMaxRigWeight, _playerM.CurAimPos, _playerM.HightAim);
                _playerM.CanShoot = !haveMaxRigWeight;
            }

            else
            {
                _playerVC.ExecuteNotSeen(_playerM.SpeedReadyShoot);
                _playerM.CanShoot = false;
            }

            _playerM.AddTimeForShoot(Time.deltaTime);

            _playerAnimVC.SetFloat();
        }

        internal void Crouch()
        {
            _playerM.IsCrouched = !_playerM.IsCrouched;
            _playerAnimVC.SetCrouch(_playerM.IsCrouched);
        }

        internal void Shift()
        {
            if (!_playerM.IsCrouched)
            {
                if (_cameraVC.Raycast(out var raycastHit))
                {
                    _playerVC.Shift(raycastHit);
                } 
            }
        }

        internal void Shoot()
        {
            if (_playerM.TimeForShoot >= 0.7 && _playerM.CanShoot)
            {
                _playerM.ResetTimeShoot();
                _playerVC.Shoot(out var startPos, out var startRot);

                _bulletCs[0].Shoot(_playerM.StrengthShoot, startPos, startRot);
            }
        }
    }
}

