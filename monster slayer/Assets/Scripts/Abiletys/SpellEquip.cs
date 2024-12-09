using System;
using System.Collections;
using System.Collections.Generic;
using Ui.Abilitys;
using UnityEngine;
using UnityEngine.UIElements;

public class SpellEquip : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private StyleSheet styleSheet;
    public CreateAbilitycards createAbilitycards;

    private void OnValidate()
    {
        CreateHotBar();
    }

    private void CreateHotBar()
    {
        var root = document.rootVisualElement;
        
        root.styleSheets.Add(styleSheet);
        
        root.Clear();

        var backgroundbox = Create<VisualElement>("backgroundBox");
        var test = Create<Label>();
        test.text = "test";
        backgroundbox.Add(test);
        
        root.Add(backgroundbox);
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
