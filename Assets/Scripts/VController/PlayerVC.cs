using UnityEngine;

namespace Game
{
    public sealed class PlayerVC
    {
        PlayerV _playerV;
        StartValues _sValues;
        Names _names;

        public Vector3 Pos => _playerV.transform.position;

        public PlayerVC(in PlayerV playerV, in StartValues sValues, in Names names)
        {
            _playerV = playerV;
            _sValues = sValues;
            _names = names;
        }

        public void Shift(in RaycastHit raycastHit)
        {
            _playerV.Agent.SetDestination(raycastHit.point);
        }

        public bool TrySeeEnemy(in bool isCrouched, in Vector3 curAimPos, ref Vector3 hightAim)
        {
            hightAim = isCrouched ? _sValues.HightAimWithCrouch : _sValues.HightAimWithoutCrouch;


            var dir = curAimPos + hightAim - _playerV.PosStartBullet;

            var angle = Vector3.Angle(dir, _playerV.Forward);


            var ray = new Ray(_playerV.PosStartBullet, dir * StartValues.DISTANCE_RAY);
            //Debug.DrawRay(_playerV.PosStartBullet, dir * DISTANCE_RAY);       

            return Physics.Raycast(ray, out var hit) && hit.collider.tag == _names.EnemyTag && angle <= StartValues.MAX_CORNER_FOR_AIM;
        }

        public void ExecuteSeen(in float speedReadyShoot, out bool haveMaxRigWeight, in Vector3 curAimPos, in Vector3 hightAim)
        {
            _playerV.RightTargetPos = Vector3.MoveTowards(_playerV.Pos, curAimPos, StartValues.DISTANCE_FROM_PLAYER) + hightAim;
            _playerV.LeftTargetPos = _playerV.RightTargetPos - _playerV.RightTarget.up * 0.1f;

            _playerV.RightTarget.LookAt(curAimPos + hightAim);
            _playerV.LeftTarget.LookAt(curAimPos + hightAim);

            _playerV.RightTarget.Rotate(_sValues.RotForRightHand);
            _playerV.LeftTarget.Rotate(_sValues.RotForLeftHand);

            haveMaxRigWeight = _playerV.RigWeight < StartValues.MAX_RIG_WEIGHT;

            if (haveMaxRigWeight)
            {
                _playerV.RigWeight += Time.deltaTime * speedReadyShoot;
            }
        }

        public void ExecuteNotSeen(in float speedReadyShoot)
        {
            if (_playerV.RigWeight > StartValues.MIN_RIG_WEIGHT)
            {
                _playerV.RigWeight -= Time.deltaTime * speedReadyShoot;
            }
        }

        public void Shoot(out Vector3 startPos, out Quaternion startRot)
        {
            startPos = _playerV.PosStartBullet;
            startRot = _playerV.RotStartBullet;

            _playerV.PlayShootSound();
        }
    }
}