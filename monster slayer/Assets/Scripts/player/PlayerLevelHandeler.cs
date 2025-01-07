using UnityEngine;

namespace player
{
    public class LevelHandeler : MonoBehaviour
    {
        public AbilityManager AbilityCheck;
        public CreateStatsinventory Statsinventory;

        public float currentXp = 0;
        public float requirerdXp = 10;
        public int playerLevel = 1;
        
        void Update()
        {
            if (currentXp >= requirerdXp)
            {
                PlayerLevelUp();
            }
        }

        void PlayerLevelUp()
        {
            playerLevel++;
            currentXp = 0;
            requirerdXp *= 1.15f;
            AbilityCheck.OnPlayerLevelUp(playerLevel);
            Statsinventory.statsLevelUp();
        }
    }
}
