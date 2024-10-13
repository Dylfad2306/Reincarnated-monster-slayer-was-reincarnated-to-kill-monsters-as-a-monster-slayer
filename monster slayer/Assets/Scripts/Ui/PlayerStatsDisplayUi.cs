using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDisplayUi : MonoBehaviour
{
    public PlayerStats PlayerStats;
    public LevelHandeler LevelHandeler;

    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerxpState;
    public TextMeshProUGUI playerCurrentLevelText;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthText.text = "HEALTH: " + PlayerStats.playerHealth.ToString();
        //playerxpState.text = LevelHandeler.currentXp.ToString() + "/" + LevelHandeler.recuiredXp.ToString() + " XP";
        //playerCurrentLevelText.text = "LEVEL: " + LevelHandeler.playerLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        //LevelHandeler.currentXp = Mathf.Round(LevelHandeler.currentXp);

        playerHealthText.text = "HEALTH: " + PlayerStats.playerHealth.ToString();
        //playerxpState.text = LevelHandeler.currentXp.ToString() + "/" + LevelHandeler.recuiredXp.ToString() + " XP";
        //playerCurrentLevelText.text = "LEVEL: " + LevelHandeler.playerLevel.ToString();
    }
}
