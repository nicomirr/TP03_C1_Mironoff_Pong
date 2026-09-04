using UnityEngine;

namespace Game.Player
{
    public class PaddleScaler : MonoBehaviour
    {
        private Transform _paddleTransform;

        private void Awake()
        {
            _paddleTransform = GetComponentInChildren<PaddleVisualTag>().transform;            
        }

        public void ChangeScale(float yScale)
        {
            _paddleTransform.localScale = new Vector3(_paddleTransform.localScale.x, yScale);
        }
    }
}

