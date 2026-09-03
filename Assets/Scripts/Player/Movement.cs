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
            Vector2 targetPosition = _rb.position + Vector2.up * (direction * movementSpeed * Time.fixedDeltaTime);          
            _rb.MovePosition(targetPosition);
        }
    }
}

