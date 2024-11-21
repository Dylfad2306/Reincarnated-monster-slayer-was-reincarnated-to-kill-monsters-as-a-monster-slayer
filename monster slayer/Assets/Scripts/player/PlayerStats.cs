using UnityEngine;

namespace player
{
    public class PlayerStats : MonoBehaviour
    {
        public GameObject cameraObject;

        public float playerHealth;
        public float playerDamage;

        private void Update()
        {
            if (playerHealth <= 0)
            {
                //Destroy(gameObject);
                //Destroy(cameraObject);
            }
        }
    }
}
