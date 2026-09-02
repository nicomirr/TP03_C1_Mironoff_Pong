using UnityEngine;

namespace Game.Player
{
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move(float direction, float movementSpeed)
        {
            _rb.linearVelocity = Vector3.up * (direction * movementSpeed);
            
        }
    }
}

