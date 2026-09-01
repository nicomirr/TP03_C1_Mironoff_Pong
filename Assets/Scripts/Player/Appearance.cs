using UnityEngine;

namespace Game.Player
{
    public class Appearance : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void RandomizeColor()
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);

            Color color = new Color(r, g, b, 1);

            _spriteRenderer.color = color;
        }
    }
}

