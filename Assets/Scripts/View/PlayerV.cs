using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

namespace Game
{
    public sealed class PlayerV : UnitV
    {
        [SerializeField] Transform _startBullet;
        Rig _rig;
        AudioSource _shootSound;

        public NavMeshAgent Agent { get; private set; }

        public Transform RightTarget { get; private set; }
        public Transform LeftTarget { get; private set; }

        public Vector3 Pos => transform.position;
        public Vector3 Forward => transform.forward;

        public Vector3 PosStartBullet => _startBullet.transform.position;
        public Quaternion RotStartBullet => _startBullet.transform.rotation;
       
        public Vector3 RightTargetPos
        {
            get => RightTarget.position;
            set => RightTarget.position = value;
        }
        public Vector3 LeftTargetPos
        {
            get => LeftTarget.position;
            set => LeftTarget.position = value;
        }
        public float RigWeight
        {
            get => _rig.weight;
            set => _rig.weight = value;
        }


        protected override void Start()
        {
            base.Start();

            _rig = transform.Find("HandsRig").GetComponent<Rig>();

            LeftTarget = _rig.transform.Find("LeftTarget");
            RightTarget = _rig.transform.Find("RightTarget");

            Agent = GetComponent<NavMeshAgent>();
            _shootSound = GetComponent<AudioSource>();
        }

        public void PlayShootSound() => _shootSound.Play();
    }
}