using UnityEngine;

namespace Game.Player
{
    public class Movement : MonoBehaviour
    {                        
        public void Move(Vector3 direction, float movementSpeed)
        {           
            this.transform.position += direction.normalized * (movementSpeed * Time.deltaTime);
        }
    }
}

