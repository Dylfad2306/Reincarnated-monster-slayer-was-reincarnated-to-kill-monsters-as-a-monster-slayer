using UnityEngine;
using UnityEngine.UIElements;

namespace Ui.Abilitys
{
    public class Createcatagorys : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        [SerializeField] private StyleSheet styleSheet;

        [SerializeField] private float lol;

        private void Start()
        {
            Generate();
        }
        private void OnValidate()
        {
            Generate();
        }

        void Generate()
        {
            var root = document.rootVisualElement;

            root.Clear();

            root.styleSheets.Add(styleSheet);

            root.AddToClassList("catagory-body");


            var passivAbilitys = Create<Button>();
            var activeAbilitys = Create<Button>("ActiveAbilitys");
            var passivAbilitysText = Create<Label>();
            var activeAbilityText = Create<Label>();

            passivAbilitysText.text = "hello!";
            activeAbilityText.text = "Hello!";


            passivAbilitys.Add(passivAbilitysText);
            activeAbilitys.Add(activeAbilityText);


            root.Add(passivAbilitys);
            root.Add(activeAbilitys);
        }

        T Create<T>(params string[] classNames) where T : VisualElement, new()
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
