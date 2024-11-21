using player;
using Ui.Abilitys;
using UnityEngine;

namespace Abiletys
{
    public class LevelAbilityCheck : MonoBehaviour
    {
       public LevelHandeler PlayerLevel;
       public CreateActiveAbilitys createActiveAbilitys;

        private string cardName;
        private string cardDescription;
        private int cardLevel;
        private int cardXp;
        public void ActiveAbilityLevelUnlocker()
        {
            if (PlayerLevel.playerLevel >= 2)
            {
                cardName = "Fireball";
                cardDescription = "castes a fire ball that sets the enemy on fire";
                cardLevel = 0;
                cardXp = 0;
                createActiveAbilitys.CreateCards(cardName, cardDescription, cardLevel, cardXp);

                cardName = "Rock shot";
                cardDescription = "shoots a rock bullet";
                cardLevel = 1;
                cardXp = 5;
                createActiveAbilitys.CreateCards(cardName, cardDescription, cardLevel, cardXp);
            }
        }

        public void PassiveAbilityLevelUnlocker()
        {
            if (PlayerLevel.playerLevel >= 2)
            {
                
            }
        }
    }
}
