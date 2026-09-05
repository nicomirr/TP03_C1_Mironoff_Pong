using UnityEngine;
using System.Collections;
using Game.Player;

namespace Game.Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float _increaseAmout = 0.2f;

        [SerializeField] private float _initialSpeed = 10f;
        [SerializeField] private float _maxSpeed = 16f;
        [SerializeField] private float _minHorizontalDirection = 0.6f;

        private float _currentSpeed;

        private BallLauncher _ballLauncher;
        private Rigidbody2D _rb;

        private bool _isLaunched;

        private void Awake()
        {
            _ballLauncher = GetComponent<BallLauncher>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private IEnumerator Start()
        {
            _currentSpeed = _initialSpeed;

            yield return _ballLauncher.LaunchRoutine();

            _isLaunched = true;
        }

        private void FixedUpdate()
        {
            if (!_isLaunched) return;

            Vector2 direction = _rb.linearVelocity.normalized;

            if (Mathf.Abs(direction.x) < _minHorizontalDirection)
            {
                direction.x = Mathf.Sign(direction.x) * _minHorizontalDirection;
            }

            _rb.linearVelocity = direction.normalized * _currentSpeed;
        }

        //Moverlo a otro lugar
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            {
                if (_currentSpeed < _maxSpeed)
                    _currentSpeed = Mathf.Clamp(_currentSpeed + _increaseAmout, _initialSpeed, _maxSpeed);
            }
        }
    }
}

