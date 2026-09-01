using UnityEngine;
using System.Collections.Generic;

namespace Game.Environment
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private List<Transform> _backgrounds = new List<Transform>();

        [SerializeField] private float _upperPosition = 19;
        [SerializeField] private float _lowerPosition = -19;

        [SerializeField] private float _movementSpeed;

        private void Update()
        {
            MoveBackgrounds();
            RepositionBackgrounds();
        }

        private void MoveBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                background.transform.position += Vector3.down * (_movementSpeed * Time.deltaTime);
            }

        }

        private void RepositionBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                if (background.transform.position.y <= _lowerPosition)
                {
                    background.transform.position = new Vector3(background.transform.position.x, _upperPosition);
                }
            }
        }
    }
}

