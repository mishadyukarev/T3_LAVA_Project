using UnityEngine;

namespace Game
{
    public sealed class CameraVC
    {
        CameraV _cameraV;
        StartValues _sValues;

        public CameraVC(in CameraV cameraV, in StartValues startValues)
        {
            _cameraV = cameraV;
            _sValues = startValues;
        }

        public void Shift(in Vector3 posPlayer)
        {
            var needPos = posPlayer + _sValues.PosFromPlayer;

            _cameraV.Pos = Vector3.Lerp(_cameraV.Pos, needPos, _sValues.SpeedCamera  * Time.deltaTime);
        }

        public bool Raycast(out RaycastHit raycastHit)
        {
            return Physics.Raycast(_cameraV.ScreenPointToRay(Input.mousePosition), out raycastHit);
        }
    }
}