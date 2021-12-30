using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "StartValues", menuName = "ScriptableObjects/StartValues")]
    public sealed class StartValues : ScriptableObject
    {
        [SerializeField] Vector3 _posFromPlayer = new Vector3(0, 7, -9);
        [SerializeField] float _speedCamera = 3;
        [SerializeField] int _amountBullets = 1;


        [Space(30)]
        public Vector3 HightAimWithoutCrouch = new Vector3(0, 1.4f, 0);
        public Vector3 HightAimWithCrouch = new Vector3(0, 0.9f, 0);
        public Vector3 RotForRightHand = new Vector3(-90, -90, 0);
        public Vector3 RotForLeftHand = new Vector3(-90, 90, 0);

        public const float DISTANCE_FROM_PLAYER = 0.3f;
        public const int DISTANCE_RAY = 100;
        public const int MAX_CORNER_FOR_AIM = 60;
        public const float MAX_RIG_WEIGHT = 1;
        public const float MIN_RIG_WEIGHT = 0;


        public Vector3 PosFromPlayer => _posFromPlayer;
        public float SpeedCamera => _speedCamera;
        public int AmountBullets => _amountBullets;
    }
}