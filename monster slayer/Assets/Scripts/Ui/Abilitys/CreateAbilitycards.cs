using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ui.Abilitys
{
    public class CreateAbilitycards : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        [SerializeField] private StyleSheet styleSheet;
        [SerializeField] private AbilityManager abilityManager;
        public List<string> selectedAbilities = new List<string>();

        private void OnValidate()
        {
            //CreateCards();
        }

        public void createActiveAbilitysCard()
        {
            List<AbilityBehaviour> availableAbilities = abilityManager.GetActiveAbilities(); // Can also use GetActive or GetPassive
            foreach (AbilityBehaviour availableAbility in availableAbilities)
            {
                CreateCards(availableAbility.AbilityName, availableAbility.Description, availableAbility._abilityLevel, availableAbility._abilityExperience, availableAbility._experienceNeededToLevelUp, availableAbility.AbilityType);
            }
        }

        public void createPassiveAbilityCard()
        {
            List<AbilityBehaviour> availableAbilities = abilityManager.GetPassiveAbilities(); // Can also use GetActive or GetPassive
            foreach (AbilityBehaviour availableAbility in availableAbilities)
            {
                CreateCards(availableAbility.AbilityName, availableAbility.Description, availableAbility._abilityLevel, availableAbility._abilityExperience, availableAbility._experienceNeededToLevelUp, availableAbility.AbilityType);
            }
        }
        
        public void CreateCards(string cardName, string cardDescription, int cardLevel, int cardXp, int cardReqXp, string abilityType)
        {
            var root = document.rootVisualElement;
            
            root.styleSheets.Add(styleSheet);
            var cardHolder = Create<VisualElement>("card-holder");
            var card = Create<Button>("card");

            var cardtitel = Create<Label>("card-titel");
            var cardDec = Create<Label>("card-description");
            var level = Create<Label>("card-level");
            var xp = Create<Label>("card-xp");

            cardtitel.text = cardName;
            cardDec.text = cardDescription;
            level.text = cardLevel.ToString();
            xp.text = cardXp.ToString() + "/" + cardReqXp.ToString();
            
            card.clicked += () =>
            {
                if (abilityType == "Active")
                {
                  if (!selectedAbilities.Contains(cardName))
                    {
                        selectedAbilities.Add(cardName);
                        //Debug.Log("Selected abilities: " + string.Join(", ", selectedAbilities));
                    }
                    else
                    {
                        selectedAbilities.Remove(cardName);
                        //Debug.Log("removed abilities: " + string.Join(", ", selectedAbilities));
                    }  
                }
                
            };
            
            cardHolder.Add(card);
            card.Add(cardtitel);
            card.Add(cardDec);
            card.Add(level);
            card.Add(xp);
            
            root.Add(cardHolder);
        }
        private T Create<T>(params string[] classNames) where T : VisualElement, new()
        {
            var ele = new T();
            foreach (var className in classNames)
            {
                ele.AddToClassList(className);
            }
            return ele;
        }
    }
}
