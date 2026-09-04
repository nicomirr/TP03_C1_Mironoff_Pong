using Game.Ball;
using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _minHorizontalDirection = 0.6f;

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

        _rb.linearVelocity = direction.normalized * _speed;
    }
}
