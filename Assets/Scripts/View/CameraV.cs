using UnityEngine;

namespace Game
{
    public struct CameraV
    {
        Camera _camera;

        public Vector3 Pos
        {
            get => _camera.transform.position;
            set => _camera.transform.position = value;
        }
        public Ray ScreenPointToRay(in Vector3 pos) => _camera.ScreenPointToRay(pos);

        public CameraV(in Camera camera)
        {
            _camera = camera;
        }
    }
}