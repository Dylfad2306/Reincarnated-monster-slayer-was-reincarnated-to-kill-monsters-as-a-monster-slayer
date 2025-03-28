using UnityEngine;

namespace player
{
    public class PlayerStats : MonoBehaviour
    {
        public CreateStatsinventory Statsinventory;

        private int playerHealth = 100;
        private int playerMaxHealth = 100;
        private int playerDamage = 1;
        private int playermana = 100;
        private int playermaxmana = 100;
        private float manacooldown = 1;
        
        public int getPlayerHealth() => playerHealth;
        public int getPlayerMaxHealth() => playerMaxHealth;
        public int getPlayerDamage() => playerDamage;
        public int getPlayerMana() => playermana;
        public int getPlayerMaxMana() => playermaxmana;
        public void setHealth(int health) => playerHealth = health;
        //public void increaseMaxHealth(int health) => playerMaxHealth += health;
        public void setmana(int mana) => playermana = mana;

        private void Update()
        {
            if (manacooldown <= Time.time && playermana <= playermaxmana - 1)
            {
                playermana++;
                manacooldown = Time.time + 2;
            }

            updatestats();
            
            if (playerHealth <= 0)
            {
                //Destroy(gameObject);
                //Destroy(cameraObject);
            }
        }

        private void updatestats()
        {
            playerHealth *= Statsinventory.healthInt;
        }
    }
}
