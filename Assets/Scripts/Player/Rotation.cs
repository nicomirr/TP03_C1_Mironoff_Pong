using UnityEngine;

namespace Game.Player
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private float _rotationAmount = 10f;
                
        public void Rotate(float direction)
        {
            this.transform.Rotate(Vector3.forward * (-direction * _rotationAmount));
        }
    }
}

