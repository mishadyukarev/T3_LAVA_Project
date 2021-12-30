using UnityEngine;

namespace Game
{
    internal sealed class Main : MonoBehaviour
    {
        //M => Model
        //V => View
        //C => Controller
        //VC => ViewController

        CPool _cPool;

        void Start()
        {
            var resources = new Resources(true);
            var vPool = new VPool(resources);

            var vCPool = new VCPool(vPool, resources);
            _cPool = new CPool(vCPool);
        }

        void Update() => _cPool.Update();
    }
}