using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float _launchForce;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.AddForce(new Vector2(-1, 0f) * _launchForce, ForceMode2D.Impulse);
    }    
}
