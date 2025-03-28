using System;
using System.Collections;
using System.Collections.Generic;
using player;
using Test;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class CreateStatsinventory : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private StyleSheet styleSheet;
    public SpawnSeketons spawnSeketons;
    public CreateProficiencyMenu proficiencyMenu;
    
    public LevelHandeler playerLevel;
        
    private bool _isUIVisible = false;

    public int strengthInt = 1;
    public int healthInt = 1;
    public int defenseint = 1;
    public int staminaInt = 1;
    public int agilityInt = 1;
    public float magicalPowerInt = 1;
    public int manaInt = 1;
    public int customPointsInt = 0;

    private Button StrengthIncrease;
    private Button HealthIncrease;
    private Button DefenseIncrease;
    private Button StaminaIncrease;
    private Button AgilityIncrease;
    private Button magicalPowerIncrease;
    private Button ManaIncrease;
    
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
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
                spawnSeketons.canSpawn = false;
            }
        }
    }
    
    public void CreateInventoryUI()
    {
        var root = document.rootVisualElement;
            
        root.styleSheets.Add(styleSheet);
        root.Clear();

        var Backgroundvisual = Create<VisualElement>("background");
        var inventoryBox = Create<VisualElement>("background-box");
        var inventoryTopBar = Create<VisualElement>("inventory-top-bar");
        var BottomPart = Create<VisualElement>("bottom-part");
        
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
        var cutomPointsText = Create<Label>("Stat-Text-And-Button");
        var Strength = Create<VisualElement>("Stat-Text-And-Button");
        var StrengthStatText = Create<Label>("strength-stat");
        StrengthIncrease = Create<Button>("strength-increase");
        var Health = Create<VisualElement>("Stat-Text-And-Button");
        var HealthStatText = Create<Label>("health-stat");
        HealthIncrease = Create<Button>("health-increase");
        var defense = Create<VisualElement>("Stat-Text-And-Button");
        var DefenseStatText = Create<Label>("defense-stat");
        DefenseIncrease = Create<Button>("defense-increase");
        var Stamina = Create<VisualElement>("Stat-Text-And-Button");
        var StaminaStatText = Create<Label>("stamina-stat");
        StaminaIncrease = Create<Button>("stamina-increase");
        var Agility = Create<VisualElement>("Stat-Text-And-Button");
        var AgilityStatText = Create<Label>("agility-stat");
        AgilityIncrease = Create<Button>("agility-increase");
        var MagicalPower = Create<VisualElement>("Stat-Text-And-Button");
        var magicalPowerStatText = Create<Label>("magical-power-stat");
        magicalPowerIncrease = Create<Button>("magical-power-increase");
        var Mana = Create<VisualElement>("Stat-Text-And-Button");
        var ManaStatText = Create<Label>("mana-stat");
        ManaIncrease = Create<Button>("mana-increase");
        
        inventoryTitel.text = "Inventory";
        itemsinventoryButtonText.text = "Items";
        equipmentinventoryButtonText.text = "Equipment";
        proficiencyButtonText.text = "Proficiency";
        statsButtonText.text = "Stats";
        //Bottom part
        caracterName.text = "Caracter Name: " + "hello";
        caracterLevel.text = "Caracter Level: " + playerLevel.playerLevel.ToString();
        caracterLevelup.text = "Caracter Level up: " + playerLevel.currentXp.ToString() + "/" + playerLevel.requirerdXp.ToString(); ;
        test.text = "Test";
        
        //7 numbers is max
        cutomPointsText.text = "Custom Points: " + customPointsInt.ToString();
        StrengthStatText.text = "Strength: " + strengthInt;
        StrengthIncrease.text = "+1";
        HealthStatText.text = "Health: " + healthInt;
        HealthIncrease.text = "+1";
        DefenseStatText.text = "Defense: " + defenseint;
        DefenseIncrease.text = "+1";
        StaminaStatText.text = "Stamina: " + staminaInt;
        StaminaIncrease.text = "+1";
        AgilityStatText.text = "Agility: " + agilityInt;
        AgilityIncrease.text = "+1";
        magicalPowerStatText.text = "MagicalPower: " + magicalPowerInt;
        magicalPowerIncrease.text = "+1";
        ManaStatText.text = "Mana: " + manaInt;
        ManaIncrease.text = "+1";
        
        
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
        //proficiencyButton.Add(proficiencyButtonText);
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
        
        stats.Add(cutomPointsText);
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

        proficiencyButton.clickable.clicked += () => { OpenProficiencyMenu(); };
        
        if (customPointsInt >= 0)
        {
            StrengthIncrease.clicked += () => { if (customPointsInt > 0) { strengthInt += 1; UpdateStats(StrengthStatText, "Strength: " + strengthInt.ToString(), cutomPointsText, "Custom Points: " + (--customPointsInt).ToString()); } };
            HealthIncrease.clicked += () => { if (customPointsInt > 0) { healthInt += 1; UpdateStats(HealthStatText, "Health: " + healthInt.ToString(), cutomPointsText, "Custom Points: " + (--customPointsInt).ToString()); } };
            DefenseIncrease.clicked += () => { if (customPointsInt > 0) { defenseint += 1; UpdateStats(DefenseStatText, "Defense: " + defenseint.ToString(), cutomPointsText, "Custom Points: " + (--customPointsInt).ToString()); } };
            StaminaIncrease.clicked += () => { if (customPointsInt > 0) { staminaInt += 1; UpdateStats(StaminaStatText, "Stamina: " + staminaInt.ToString(), cutomPointsText, "Custom Points: " + (--customPointsInt).ToString()); } };
            AgilityIncrease.clicked += () => { if (customPointsInt > 0) { agilityInt += 1; UpdateStats(AgilityStatText, "Agility: " + agilityInt.ToString(), cutomPointsText, "Custom Points: " + (--customPointsInt).ToString()); } };
            magicalPowerIncrease.clicked += () => { if (customPointsInt > 0) { magicalPowerInt += 1; UpdateStats(magicalPowerStatText, "MagicalPower: " + magicalPowerInt.ToString(), cutomPointsText, "Custom Points: " + (--customPointsInt).ToString()); } };
            ManaIncrease.clicked += () => { if (customPointsInt > 0) { manaInt += 1; UpdateStats(ManaStatText, "Mana: " + manaInt.ToString(), cutomPointsText, "Custom Points: " + (--customPointsInt).ToString()); } };
        }
        StrengthIncrease.clicked += () => { Debug.Log("Strength Button Clicked!"); };
        Backgroundvisual.Add(inventoryBox);
        root.Add(Backgroundvisual);
    }

    private void UpdateStats(Label statLabel, string statText, Label customPointsLabel, string customPointsText)
    {
        statLabel.text = statText;
        customPointsLabel.text = customPointsText;
    }
    
    void OpenProficiencyMenu()
    {
        RemoveInventory();
        proficiencyMenu.createProficiencyMenu();
    }

    public void statsLevelUp()
    {
        staminaInt += 1;
        agilityInt += 1;
        strengthInt += 1;
        healthInt += 1;
        defenseint += 1;
        magicalPowerInt += 1;
        manaInt += 1;
        customPointsInt += 2;
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
