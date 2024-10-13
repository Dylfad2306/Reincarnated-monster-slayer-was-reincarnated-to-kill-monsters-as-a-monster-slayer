using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class LevelHandeler : MonoBehaviour
{
    AbilityUnlocker unlockAbilitys;

    float currentXp = 0;
    float requirerdXp = 10;
    public int playerLevel = 1;

    private void Start()
    {
        unlockAbilitys = GetComponent<AbilityUnlocker>();
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
        unlockAbilitys.AbilityLevelUnlocker();
    }
}
