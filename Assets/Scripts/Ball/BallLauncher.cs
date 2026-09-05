using System.Collections;
using UnityEngine;
using Game.Gameplay;

namespace Game.Ball
{
    public class BallLauncher : MonoBehaviour
    {
        [SerializeField] private float _launchForce = 10.0f;
        [SerializeField] private float _launchDelay = 2f;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public IEnumerator LaunchRoutine()
        {
            yield return new WaitForSeconds(_launchDelay);

            float randomXDir = Random.value < 0.5f ? -1f : 1f;
            float randomYDir = Random.value < 0.5f ? -1f : 1f;

            Vector2 direction = new Vector2(randomXDir, randomYDir).normalized;

            _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);

            GameplayEvents.RaiseRoundStarted();
        }
    }
}

