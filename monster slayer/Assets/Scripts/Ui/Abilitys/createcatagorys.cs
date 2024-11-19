using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class createcatagorys : MonoBehaviour
{
    [SerializeField] private UIDocument _document;
    [SerializeField] private StyleSheet _styleSheet;

    [SerializeField] private float _lol;

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
        var root = _document.rootVisualElement;

        root.Clear();

        root.styleSheets.Add(_styleSheet);

        root.AddToClassList("catagory-body");


        var PassivAbilitys = Create<Button>("passivAbilitys");
        var ActiveAbilitys = Create<Button>("ActiveAbilitys");
        // add a way to give ability text a text
        var PassivAbilitysText = Create<TextField>();
        var ActiveAbilityText = Create<TextField>();

        PassivAbilitys.Add(PassivAbilitysText);
        ActiveAbilitys.Add(ActiveAbilityText);


        root.Add(PassivAbilitys);
        root.Add(ActiveAbilitys);
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
