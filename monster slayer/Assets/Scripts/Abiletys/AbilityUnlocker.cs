using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlocker : MonoBehaviour
{
    LevelHandeler PlayerLevel;


    private void Start()
    {
        PlayerLevel = GetComponent<LevelHandeler>();
    }

    private void Update()
    {
        //for (int i = 0; playerAbilitys[i] == "Fireball")
    }
    public void AbilityLevelUnlocker()
    {
        if (PlayerLevel.playerLevel == 2)
        {
            //unlockFireBall();
        }
    }
}
