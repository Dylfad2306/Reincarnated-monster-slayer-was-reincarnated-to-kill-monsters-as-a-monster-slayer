using System.Collections;
using System.Collections.Generic;
using Ui.Abilitys;
using UnityEngine;

public class LevelAbilityCheck : MonoBehaviour
{
    LevelHandeler PlayerLevel;
    PlayerAbilityUnlock PlayerAbility;
    CreateActiveAbilitys createActiveAbilitys;


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
            //createActiveAbilitys.createCards();
        }
    }
}
