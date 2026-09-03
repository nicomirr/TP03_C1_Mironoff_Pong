using UnityEngine;

namespace Game.Ball
{
    public class BallLauncher : MonoBehaviour
    {       
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Launch(float speed)
        {
            _rb.AddForce(new Vector2(-1, 1f) * speed, ForceMode2D.Impulse);
        }
    }
}

