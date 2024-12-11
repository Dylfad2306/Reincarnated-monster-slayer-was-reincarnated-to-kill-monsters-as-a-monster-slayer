using System;
using System.Collections.Generic;
using Ui.Abilitys;
using UnityEngine;
using UnityEngine.UIElements;
public interface IAbility
{
    void ActivateAbility();
}
public class SpellEquip : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private StyleSheet styleSheet;
    public CreateAbilitycards createAbilitycards;
    
    private Dictionary<string, IAbility> abilityDictionary = new Dictionary<string, IAbility>();
    
    void Start()
    {
        // Populate the dictionary with available abilities
        abilityDictionary.Add("Fireball", gameObject.AddComponent<FireBall>()); 
        abilityDictionary.Add("rockshot", gameObject.AddComponent<RockShot>());
        abilityDictionary.Add("waterball", gameObject.AddComponent<waterball>());
        //abilityDictionary.Add("IceBlast", new IceBlast());
    }
    void Update()
    {
        // Ensure the selectedAbilities list is not null
        if (createAbilitycards == null || createAbilitycards.selectedAbilities == null) return;

        // Loop through the selected abilities
        for (int i = 0; i < createAbilitycards.selectedAbilities.Count; i++)
        {
            if (i >= 10) break; // Only handle up to 10 abilities

            // Check for corresponding key press (1-9, 0 maps to index 9)
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ActivateAbility(createAbilitycards.selectedAbilities[i]);
            }
        }
    }
    private void FixedUpdate()
    {
        CreateHotBar();
    }
    
    private void ActivateAbility(string abilityName)
    {
        // Find a GameObject in the scene with the ability script attached
        MonoBehaviour ability = FindAbilityByName(abilityName);

        if (ability is IAbility abilityScript)
        {
            // Activate the ability
            abilityScript.ActivateAbility();
        }
        else
        {
            Debug.LogWarning($"Ability '{abilityName}' not found or does not implement IAbility.");
        }
    }
    private MonoBehaviour FindAbilityByName(string abilityName)
    {
        // Search all active GameObjects for a component matching the ability name
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            MonoBehaviour ability = obj.GetComponent(abilityName) as MonoBehaviour;
            if (ability != null)
            {
                return ability;
            }
        }

        // If not found, log a warning
        Debug.LogWarning($"Ability script '{abilityName}' not found in the scene.");
        return null;
    }
    
    private void CreateHotBar()
    {
        var root = document.rootVisualElement;
        
        root.styleSheets.Add(styleSheet);
        
        root.Clear();

        var backgroundbox = Create<VisualElement>("backgroundBox");
        
        var hotbar1 = Create<VisualElement>("hotbarbox");
        var hotbar1Number = Create<Label>("hotbarbox-number");
        var hotbar1Name = Create<Label>("hotbarbox-name");
        var hotbar2 = Create<VisualElement>("hotbarbox");
        var hotbar2Number = Create<Label>("hotbarbox-number");
        var hotbar2Name = Create<Label>("hotbarbox-name");
        var hotbar3 = Create<VisualElement>("hotbarbox");
        var hotbar3Number = Create<Label>("hotbarbox-number");
        var hotbar3Name = Create<Label>("hotbarbox-name");
        var hotbar4 = Create<VisualElement>("hotbarbox");
        var hotbar4Number = Create<Label>("hotbarbox-number");
        var hotbar4Name = Create<Label>("hotbarbox-name");
        var hotbar5 = Create<VisualElement>("hotbarbox");
        var hotbar5Number = Create<Label>("hotbarbox-number");
        var hotbar5Name = Create<Label>("hotbarbox-name");
        var hotbar6 = Create<VisualElement>("hotbarbox");
        var hotbar6Number = Create<Label>("hotbarbox-number");
        var hotbar6Name = Create<Label>("hotbarbox-name");
        var hotbar7 = Create<VisualElement>("hotbarbox");
        var hotbar7Number = Create<Label>("hotbarbox-number");
        var hotbar7Name = Create<Label>("hotbarbox-name");
        var hotbar8 = Create<VisualElement>("hotbarbox");
        var hotbar8Number = Create<Label>("hotbarbox-number");
        var hotbar8Name = Create<Label>("hotbarbox-name");
        var hotbar9 = Create<VisualElement>("hotbarbox");
        var hotbar9Number = Create<Label>("hotbarbox-number");
        var hotbar9Name = Create<Label>("hotbarbox-name");
        var hotbar10 = Create<VisualElement>("hotbarbox");
        var hotbar10Number = Create<Label>("hotbarbox-number");
        var hotbar10Name = Create<Label>("hotbarbox-name");
        
        hotbar1Number.text = "1";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 0)
                {
                    hotbar1Name.text = createAbilitycards.selectedAbilities[0].ToString();
                } 
        }
        else
        {
            hotbar1Name.text = "";
        }
        
        hotbar2Number.text = "2";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 1)
            {
                hotbar2Name.text = createAbilitycards.selectedAbilities[1].ToString();
            } 
        }
        else
        {
            hotbar2Name.text = "";
        }
        
        hotbar3Number.text = "3";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 2)
            {
                hotbar3Name.text = createAbilitycards.selectedAbilities[2].ToString();
            } 
        }
        else
        {
            hotbar3Name.text = "";
        }
        
        hotbar4Number.text = "4";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 3)
            {
                hotbar4Name.text = createAbilitycards.selectedAbilities[3].ToString();
            } 
        }
        else
        {
            hotbar4Name.text = "";
        }
        
        hotbar5Number.text = "5";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 4)
            {
                hotbar5Name.text = createAbilitycards.selectedAbilities[4].ToString();
            } 
        }
        else
        {
            hotbar5Name.text = "";
        }
        
        hotbar6Number.text = "6";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 5)
            {
                hotbar6Name.text = createAbilitycards.selectedAbilities[5].ToString();
            } 
        }
        else
        {
            hotbar6Name.text = "";
        }
        
        hotbar7Number.text = "7";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 6)
            {
                hotbar7Name.text = createAbilitycards.selectedAbilities[6].ToString();
            } 
        }
        else
        {
            hotbar7Name.text = "";
        }
        
        hotbar8Number.text = "8";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 7)
            {
                hotbar8Name.text = createAbilitycards.selectedAbilities[7].ToString();
            } 
        }
        else
        {
            hotbar8Name.text = "";
        }
        
        hotbar9Number.text = "9";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 8)
            {
                hotbar9Name.text = createAbilitycards.selectedAbilities[8].ToString();
            } 
        }
        else
        {
            hotbar9Name.text = "";
        }
        
        hotbar10Number.text = "10";
        if (createAbilitycards.selectedAbilities != null)
        { 
            if (createAbilitycards.selectedAbilities.Count > 9)
            {
                hotbar10Name.text = createAbilitycards.selectedAbilities[9].ToString();
            } 
        }
        else
        {
            hotbar10Name.text = "";
        }
        
        hotbar1.Add(hotbar1Number);
        hotbar1.Add(hotbar1Name);
        
        hotbar2.Add(hotbar2Number);
        hotbar2.Add(hotbar2Name);
        
        hotbar3.Add(hotbar3Number);
        hotbar3.Add(hotbar3Name);
        
        hotbar4.Add(hotbar4Number);
        hotbar4.Add(hotbar4Name);
        
        hotbar5.Add(hotbar5Number);
        hotbar5.Add(hotbar5Name);
        
        hotbar6.Add(hotbar6Number);
        hotbar6.Add(hotbar6Name);
        
        hotbar7.Add(hotbar7Number);
        hotbar7.Add(hotbar7Name);
        
        hotbar8.Add(hotbar8Number);
        hotbar8.Add(hotbar8Name);
        
        hotbar9.Add(hotbar9Number);
        hotbar9.Add(hotbar9Name);
        
        hotbar10.Add(hotbar10Number);
        hotbar10.Add(hotbar10Name);
        
        backgroundbox.Add(hotbar1 );
        backgroundbox.Add(hotbar2 );
        backgroundbox.Add(hotbar3 );
        backgroundbox.Add(hotbar4 );
        backgroundbox.Add(hotbar5 );
        backgroundbox.Add(hotbar6 );
        backgroundbox.Add(hotbar7 );
        backgroundbox.Add(hotbar8 );
        backgroundbox.Add(hotbar9 );
        backgroundbox.Add(hotbar10 );
        
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
