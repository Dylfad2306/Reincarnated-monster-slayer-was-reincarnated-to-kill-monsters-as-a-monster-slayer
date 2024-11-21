using UnityEngine;
using UnityEngine.UIElements;

namespace Ui.Abilitys
{
    public class CreateActiveAbilitys : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        [SerializeField] private StyleSheet styleSheet;

        private void OnValidate()
        {
            //CreateCards();
        }
        public void CreateCards(string cardName, string cardDescription, int cardLevel, int cardXp)
        {
            var root = document.rootVisualElement;
            
            root.styleSheets.Add(styleSheet);
            var cardHolder = Create<VisualElement>("card-holder");
            var card = Create<VisualElement>("card");

            var cardtitel = Create<Label>("card-titel");
            var cardDec = Create<Label>("card-description");
            var level = Create<Label>("card-level");
            var xp = Create<Label>("card-xp");

            cardtitel.text = cardName;
            cardDec.text = cardDescription;
            level.text = cardLevel.ToString();
            xp.text = cardXp.ToString();
            
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
