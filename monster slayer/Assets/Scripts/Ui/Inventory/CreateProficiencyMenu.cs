using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateProficiencyMenu : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private StyleSheet styleSheet;

    public CreateStatsinventory Statsinventory;

    private void OnValidate()
    {
        //createProficiencyMenu();
    }

    public void createProficiencyMenu()
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
        //Bottom part creation
        
        var swordmastercard = Create<VisualElement>("master-card");
        var swordmastercardtop = Create<VisualElement>("master-card-top");
        var swordmastercardbottom = Create<VisualElement>("master-card-bottom");
        var swordmastericon = Create<Image>("master-icon");
        var swordmastertitle = Create<Label>("sword-master");
        var swordmasterlevel = Create<Label>("sword-master-level");
        var swordmasterxp = Create<Label>("sword-master-xp");
        
        var magicmastercard = Create<VisualElement>("master-card");
        var magicmastercardtop = Create<VisualElement>("master-card-top");
        var magicmastercardbottom = Create<VisualElement>("master-card-bottom");
        var magicmastericon = Create<Image>("master-icon");
        var magicmastertitle = Create<Label>("magic-master");
        var magicmasterlevel = Create<Label>("magic-master-level");
        var magicmasterxp = Create<Label>("magic-master-xp");
        
        
        inventoryTitel.text = "proficiency";
        itemsinventoryButtonText.text = "Items";
        equipmentinventoryButtonText.text = "Equipment";
        proficiencyButtonText.text = "Proficiency";
        statsButtonText.text = "Stats";
        //Bottom part asign info
        
        swordmastericon.image = Resources.Load("Icons/swordmaster", typeof(Texture2D)) as Texture2D;
        swordmastertitle.text = "Sword master";
        swordmasterlevel.text = "Swordmaster level: 1";
        swordmasterxp.text = "Swordmaster xp: 0 / 1000";
        
        magicmastericon.image = Resources.Load("Icons/magicmaster", typeof(Texture2D)) as Texture2D;
        magicmastertitle.text = "Magic master";
        magicmasterlevel.text = "Magicmaster level: 1";
        magicmasterxp.text = "Magicmaster xp: 0 / 1000";
        
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
        //bottom part add it together
        BottomPart.Add(swordmastercard);
        swordmastercard.Add(swordmastercardtop);
        swordmastercard.Add(swordmastercardbottom);
        swordmastercardtop.Add(swordmastericon);
        swordmastercardtop.Add(swordmastertitle);
        swordmastercardbottom.Add(swordmasterlevel);
        swordmastercardbottom.Add(swordmasterxp);
        
        BottomPart.Add(magicmastercard);
        magicmastercard.Add(magicmastercardtop);
        magicmastercard.Add(magicmastercardbottom);
        magicmastercardtop.Add(magicmastericon);
        magicmastercardtop.Add(magicmastertitle);
        magicmastercardbottom.Add(magicmasterlevel);
        magicmastercardbottom.Add(magicmasterxp);
        
        root.Add(Backgroundvisual);
        
        statsButton.clicked += Statsinventory.CreateInventoryUI;
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
