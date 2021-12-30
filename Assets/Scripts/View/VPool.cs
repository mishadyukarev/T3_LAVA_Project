using UnityEditor;
using UnityEngine;

namespace Game
{
    public struct VPool
    {
        public readonly CameraV CameraV;
        public readonly PlayerV PlayerV;
        public readonly EnemyV[] EnemyVs;
        public readonly BulletV[] BulletVs;

        public VPool(in Resources resources)
        {
            CameraV = new CameraV(Camera.main);
            PlayerV = GameObject.FindObjectOfType<PlayerV>();
            EnemyVs = GameObject.FindObjectsOfType<EnemyV>();
            for (var i = 0; i < EnemyVs.Length; i++) EnemyVs[i].Idx = i;

            var amountBullets = resources.StartValues.AmountBullets;
            var parentForBullets = new GameObject("Bullets");
            BulletVs = new BulletV[amountBullets];
            for (var i = 0; i < BulletVs.Length; i++)
            {
                BulletVs[i] = GameObject.Instantiate(resources.Bullet.GetComponent<BulletV>(), parentForBullets.transform);
                BulletVs[i].gameObject.SetActive(false);
            }
        }
    }
}