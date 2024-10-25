using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class LevelHandeler : MonoBehaviour
{
    LevelAbilityCheck AbilityCheck;

    public float currentXp = 0;
    public float requirerdXp = 10;
    public int playerLevel = 1;

    private void Start()
    {
        AbilityCheck = GetComponent<LevelAbilityCheck>();
    }

    void Update()
    {
        if (currentXp >= requirerdXp)
        {
            PlayerLevelUp();
        }
    }

    void PlayerLevelUp()
    {
        playerLevel++;
        currentXp = 0;
        requirerdXp *= 1.15f;
        AbilityCheck.AbilityLevelUnlocker();
    }
}
