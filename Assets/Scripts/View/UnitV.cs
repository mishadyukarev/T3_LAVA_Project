using UnityEngine;

namespace Game
{
    public abstract class UnitV : MonoBehaviour
    {
        Animator _animator;

        public bool EnabledAnim
        {
            get => _animator.enabled;
            set => _animator.enabled = value;
        }

        protected virtual void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetBoolAnim(in string name, in bool b) => _animator.SetBool(name, b);
        public void SetFloatAnim(in string name, in float f) => _animator.SetFloat(name, f);
    }
}