using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIManager : MonoBehaviour
{
    UIDocument UIDocument;
    VisualElement root;

    Label displayHealth;
    Label displayLevel;
    Label displayLevelXp;

    PlayerStats playerStats;
    LevelHandeler playerLevel;

    GameObject playerobj;

    private void Start()
    {
        playerobj = GameObject.Find("playerObj");
        playerStats = playerobj.GetComponent<PlayerStats>();
        playerLevel = playerobj.GetComponent<LevelHandeler>();

        UIDocument = GetComponent<UIDocument>();
        root = UIDocument.rootVisualElement;

        displayHealth = root.Q("Health-number") as Label;
        displayLevel = root.Q("Level-number") as Label;
        displayLevelXp = root.Q("LevelXp-number") as Label;

        //displayHealth = root.Q<Label>("display-health");
    }

    private void Update()
    {
        displayHealth.text = playerStats.playerHealth.ToString();
        displayLevel.text = playerLevel.playerLevel.ToString();
        displayLevelXp.text = playerLevel.currentXp.ToString() + " / " + playerLevel.requirerdXp.ToString();
        
    }
}