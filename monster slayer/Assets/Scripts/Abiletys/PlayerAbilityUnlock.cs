using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityUnlock : MonoBehaviour
{

    List<string>playerAbilitys = new List<string>();

    [Header("Card objects")]
    public GameObject fireCard;

    public void unlockFireBall()
    {
        fireCard.SetActive(true);
    }


}
