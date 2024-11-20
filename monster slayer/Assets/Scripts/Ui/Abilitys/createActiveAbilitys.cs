using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

namespace Ui.Abilitys
{
    public class CreateActiveAbilitys : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        [SerializeField] private StyleSheet styleSheet;

        public void createCards(string cardName, string cardDescription, int cardLevel, int cardXp)
        {
            var root = document.rootVisualElement;
            
            root.styleSheets.Add(styleSheet);

            var test = Create<Label>();
            test.text = "Test";
            
            root.Add(test);
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
