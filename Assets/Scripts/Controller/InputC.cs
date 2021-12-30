using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public sealed class InputC : IUpdate
    {
        PlayerC _playerC;

        public InputC(in PlayerC playerC)
        {
           _playerC = playerC;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if (Input.GetKey(KeyCode.Mouse0)) _playerC.Shoot();
            if (Input.GetKey(KeyCode.Mouse1)) _playerC.Shift();
            if (Input.GetKeyDown(KeyCode.LeftControl)) _playerC.Crouch();
        }
    }
}