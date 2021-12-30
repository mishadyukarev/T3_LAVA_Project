using UnityEngine;

namespace Game
{
    public struct Resources
    {
        public readonly StartValues StartValues;
        public readonly Names Names;
        public readonly GameObject Bullet;

        public Resources(in bool needUpload)
        {
            if (needUpload)
            {
                StartValues = UnityEngine.Resources.Load<StartValues>("StartValues");
                Names = UnityEngine.Resources.Load<Names>("Names");
                Bullet = UnityEngine.Resources.Load<GameObject>("Bullet");

            }
            else throw new System.Exception("Турак");
        }
    }
}