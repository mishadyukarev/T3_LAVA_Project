namespace Game
{
    public sealed class PlayerAnimationVC
    {
        PlayerV _playerV;

        public PlayerAnimationVC(in PlayerV playerV)
        {
            _playerV = playerV;
        }

        public void SetCrouch(bool haveCrouch)
        {
            _playerV.SetBoolAnim(Names.CROUCHED_NAME_IN_ANIMATOR, haveCrouch);
        }

        public void SetFloat()
        {
            _playerV.SetFloatAnim(Names.BLEND_NAME_IN_ANIMATOR, _playerV.Agent.velocity.magnitude / _playerV.Agent.speed * 2);
        }
    }
}