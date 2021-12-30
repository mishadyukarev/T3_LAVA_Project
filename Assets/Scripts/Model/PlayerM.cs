using System;
using UnityEngine;

namespace Game
{
    public sealed class PlayerM
    {
        public Vector3 CurAimPos;
        public Vector3 HightAim;

        public float SpeedReadyShoot = 3;
        public bool CanShoot;
        public int StrengthShoot = 11000;
        public bool IsCrouched;

        public float TimeForShoot { get; private set; }
        public void ResetTimeShoot() => TimeForShoot = default;
        public void AddTimeForShoot(in float adding)
        {
            if (adding < 0) throw new Exception("Need positive number");
            if (adding == 0) throw new Exception("Zero number");

            TimeForShoot += adding;
        }
    }
}