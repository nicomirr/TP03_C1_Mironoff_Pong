using Game.Ball;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _minHorizontalDirection = 0.6f;
    [SerializeField] private float _speed = 10f;

    private Rigidbody2D _rb;
    private BallLauncher _ballLauncher;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ballLauncher = GetComponent<BallLauncher>();
    }

    private void Start()
    {
        _ballLauncher.Launch(_speed);
    }

    private void FixedUpdate()
    {
        Vector2 direction = _rb.linearVelocity.normalized;

        if (Mathf.Abs(direction.x) < _minHorizontalDirection)
        {
            direction.x = Mathf.Sign(direction.x) * _minHorizontalDirection;
        }

        _rb.linearVelocity = direction.normalized * _speed;
    }
}
