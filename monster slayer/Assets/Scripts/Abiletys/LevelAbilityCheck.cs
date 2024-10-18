using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAbilityCheck : MonoBehaviour
{
    LevelHandeler PlayerLevel;
    PlayerAbilityUnlock PlayerAbility;


    private void Start()
    {
        PlayerLevel = GetComponent<LevelHandeler>();
        PlayerAbility = GetComponent<PlayerAbilityUnlock>();
    }

    private void Update()
    {
        //for (int i = 0; playerAbilitys[i] == "Fireball")
    }
    public void AbilityLevelUnlocker()
    {
        if (PlayerLevel.playerLevel == 2)
        {
            PlayerAbility.unlockFireBall();
        }
    }
}
