using UnityEngine;

namespace player
{
    public class PlayerStats : MonoBehaviour
    {
        public GameObject cameraObject;

        public float playerHealth = 100;
        public float playerMaxHealth = 100;
        public float playerDamage = 5;
        public float playermana = 100;
        public float playermaxmana = 100;
        public float manacooldown = 1;

        private void Update()
        {
            if (manacooldown <= Time.time && playermana <= playermaxmana - 1)
            {
                playermana++;
                manacooldown = Time.time + 2;
            }
            
            
            if (playerHealth <= 0)
            {
                //Destroy(gameObject);
                //Destroy(cameraObject);
            }
        }
    }
}
