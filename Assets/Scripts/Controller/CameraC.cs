using UnityEngine;

namespace Game
{
    public class CameraC : IUpdate
    {
        readonly PlayerVC _playerVC;
        readonly CameraVC _cameraVC;    

        public CameraC(in VCPool vCPool)
        {
            _playerVC = vCPool.PlayerVC;
            _cameraVC = vCPool.CameraVC;     
        }

        public void Update()
        {
            _cameraVC.Shift(_playerVC.Pos);
        }
    }
}