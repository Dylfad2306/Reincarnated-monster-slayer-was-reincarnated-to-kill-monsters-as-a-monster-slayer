using System;
using System.Collections;
using System.Collections.Generic;
using Test;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class CreateStatsInventory : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private StyleSheet styleSheet;
    public SpawnSeketons spawnSeketons;
        
    private bool _isUIVisible = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (_isUIVisible)
            {
                _isUIVisible = false;
                RemoveInventory();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
                spawnSeketons.canSpawn = true;
            }
            else
            {
                _isUIVisible = true;
                CreateInventoryUI();
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 0f;
                spawnSeketons.canSpawn = false;
            }
        }
    }

    private void CreateInventoryUI()
    {
        var root = document.rootVisualElement;
            
        root.styleSheets.Add(styleSheet);
        root.Clear();

        var Backgroundvisual = Create<VisualElement>("background");
        var inventoryBox = Create<VisualElement>("background-box");
        var BottomPart = Create<VisualElement>("bottom-part");
        
        var inventoryTopBar = Create<VisualElement>("inventory-top-bar");
        var inventoryTitel = Create<Label>("inventory-title");
        var buttonGroup = Create<VisualElement>("button-group");
        var itemsinventoryButton = Create<Button>("menue-buttons");
        var equipmentinventoryButton = Create<Button>("menue-buttons");
        var proficiencyButton = Create<Button>("menue-buttons");
        var proficiencyButtonText = Create<Label>();
        var statsButton = Create<Button>("menue-buttons");
        var statsButtonText = Create<Label>();
        var itemsinventoryButtonText = Create<Label>();
        var equipmentinventoryButtonText = Create<Label>();
        
        
        var caracterAndStats = Create<VisualElement>("caracter-and-stats");
        var caracterStats = Create<VisualElement>("caracter-stats");
        var caracterIcon = Create<Image>("caracter-icon");
        var caracterName = Create<Label>("caracter-name");
        var caracterLevel = Create<Label>("caracter-level");
        var caracterLevelup = Create<Label>("caracter-level-up");
        var test = Create<Label>();
        
        var stats = Create<VisualElement>("stats");
        var Strength = Create<VisualElement>("Stat-Text-And-Button");
        var StrengthStatText = Create<Label>("strength-stat");
        var StrengthIncrease = Create<Button>("strength-increase");
        var Health = Create<VisualElement>("Stat-Text-And-Button");
        var HealthStatText = Create<Label>("health-stat");
        var HealthIncrease = Create<Button>("health-increase");
        var defense = Create<VisualElement>("Stat-Text-And-Button");
        var DefenseStatText = Create<Label>("defense-stat");
        var DefenseIncrease = Create<Button>("defense-increase");
        var Stamina = Create<VisualElement>("Stat-Text-And-Button");
        var StaminaStatText = Create<Label>("stamina-stat");
        var StaminaIncrease = Create<Button>("stamina-increase");
        var Agility = Create<VisualElement>("Stat-Text-And-Button");
        var AgilityStatText = Create<Label>("agility-stat");
        var AgilityIncrease = Create<Button>("agility-increase");
        var MagicalPower = Create<VisualElement>("Stat-Text-And-Button");
        var magicalPowerStatText = Create<Label>("magical-power-stat");
        var magicalPowerIncrease = Create<Button>("magical-power-increase");
        var Mana = Create<VisualElement>("Stat-Text-And-Button");
        var ManaStatText = Create<Label>("mana-stat");
        var ManaIncrease = Create<Button>("mana-increase");
        
        inventoryTitel.text = "Inventory";
        itemsinventoryButtonText.text = "Items";
        equipmentinventoryButtonText.text = "Equipment";
        proficiencyButtonText.text = "Proficiency";
        statsButtonText.text = "Stats";
        //Bottom part
        caracterName.text = "Caracter Name: " + "hello";
        caracterLevel.text = "Caracter Level: " + "53";
        caracterLevelup.text = "Caracter Level up: " + "567 / 10495";
        test.text = "Test";
        
        //7 numbers is max
        StrengthStatText.text = "Strength: " + "5";
        StrengthIncrease.text = "+1";
        HealthStatText.text = "Health: " + "5";
        HealthIncrease.text = "+1";
        DefenseStatText.text = "Defense: " + "5";
        DefenseIncrease.text = "+1";
        StaminaStatText.text = "Stamina: " + "5";
        StaminaIncrease.text = "+1";
        AgilityStatText.text = "Agility: " + "5";
        AgilityIncrease.text = "+1";
        magicalPowerStatText.text = "Magic strength: " + "5";
        magicalPowerIncrease.text = "+1";
        ManaStatText.text = "Mana: " + "5";
        ManaIncrease.text = "+1";
        
        Backgroundvisual.Add(inventoryBox);
        //inventory items
        inventoryBox.Add(inventoryTopBar);
        inventoryBox.Add(BottomPart);
        //top section with buttons
        inventoryTopBar.Add(inventoryTitel);
        inventoryTopBar.Add(buttonGroup);
        buttonGroup.Add(itemsinventoryButton);
        itemsinventoryButton.Add(itemsinventoryButtonText);
        buttonGroup.Add(equipmentinventoryButton);
        equipmentinventoryButton.Add(equipmentinventoryButtonText);
        buttonGroup.Add(proficiencyButton);
        proficiencyButton.Add(proficiencyButtonText);
        buttonGroup.Add(statsButton);
        statsButton.Add(statsButtonText);
        //Bottom parts
        BottomPart.Add(caracterAndStats);
        caracterAndStats.Add(caracterIcon);
        caracterIcon.Add(test);
        caracterAndStats.Add(caracterStats);
        caracterStats.Add(caracterName);
        caracterStats.Add(caracterLevel);
        caracterStats.Add(caracterLevelup);
        
        BottomPart.Add(stats);
        
        stats.Add(Strength);
        Strength.Add(StrengthStatText);
        Strength.Add(StrengthIncrease);
        stats.Add(Health);
        Health.Add(HealthStatText);
        Health.Add(HealthIncrease);
        stats.Add(defense);
        defense.Add(DefenseStatText);
        defense.Add(DefenseIncrease);
        stats.Add(Stamina);
        Stamina.Add(StaminaStatText);
        Stamina.Add(StaminaIncrease);
        stats.Add(Agility);
        Agility.Add(AgilityStatText);
        Agility.Add(AgilityIncrease);
        stats.Add(MagicalPower);
        MagicalPower.Add(magicalPowerStatText);
        MagicalPower.Add(magicalPowerIncrease);
        stats.Add(Mana);
        Mana.Add(ManaStatText);
        Mana.Add(ManaIncrease);

        proficiencyButton.clicked += OpenProficiencyMenu;
        
        root.Add(Backgroundvisual);
    }

    public void OpenProficiencyMenu()
    {
        
    }
    
    
    
    
    private void RemoveInventory()
    {
        var root = document.rootVisualElement;
            
        root.Clear();
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
