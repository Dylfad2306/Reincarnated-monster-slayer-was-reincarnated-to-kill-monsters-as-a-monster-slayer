using System;
using Test;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

namespace Ui.Abilitys
{
    public class Createcatagorys : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        [SerializeField] private StyleSheet styleSheet;
        
        public CreateAbilitycards CreateActiveAbilitys;
        public SpawnSeketons SpawnSeketons;
        
        private bool _isUIVisible = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (_isUIVisible)
                {
                    _isUIVisible = false;
                    RemoveGeneratedUI();
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Time.timeScale = 1f;
                    SpawnSeketons.canSpawn = true;
                }
                else
                {
                    _isUIVisible = true;
                    Generate();
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    Time.timeScale = 0f;
                    SpawnSeketons.canSpawn = false;
                }
            }
        }

        private void Generate()
        {
            var root = document.rootVisualElement;
            
            root.styleSheets.Add(styleSheet);

            root.AddToClassList("catagory-body");
            
            var passivAbilitys = Create<Button>();
            var activeAbilitys = Create<Button>("ActiveAbilitys");
            var passivAbilitysText = Create<Label>();
            var activeAbilityText = Create<Label>();

            passivAbilitysText.text = "Passive ability's!";
            activeAbilityText.text = "Active ability's!";
            
            passivAbilitys.Add(passivAbilitysText);
            activeAbilitys.Add(activeAbilityText);

            passivAbilitys.clicked += PassivAbilitysOnclicked;
            activeAbilitys.clicked += ActiveAbilitysOnclicked;
            
            root.Add(passivAbilitys);
            root.Add(activeAbilitys);
        }
        private void RemoveGeneratedUI()
        {
            var root = document.rootVisualElement;
            
            root.Clear();
        }
        
        void PassivAbilitysOnclicked()
        {
            print("Passivabilitys on clicked");
            //showes passive abilitys and generate them
            RemoveGeneratedUI();
            CreateActiveAbilitys.createPassiveAbilityCard();
        }
        void ActiveAbilitysOnclicked()
        {
            //showes active abilitys and generate them
            RemoveGeneratedUI();
            CreateActiveAbilitys.createActiveAbilitysCard();
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
