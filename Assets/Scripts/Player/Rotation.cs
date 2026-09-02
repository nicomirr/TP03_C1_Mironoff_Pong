using UnityEngine;

namespace Game.Player
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private float _rotationAmount = 10f;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Rotate(float direction)
        {
            this.transform.Rotate(Vector3.forward * (-direction * _rotationAmount));
        }
    }
}

