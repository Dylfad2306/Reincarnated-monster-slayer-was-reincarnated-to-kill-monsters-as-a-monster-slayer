using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class LevelHandeler : MonoBehaviour
{

    public PlayerStats playerStats;
    public float currentXp = 0;
    public float recuiredXp = 10;
    public int playerLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentXp >= recuiredXp)
        {
            playerLevel++;
            currentXp = 0;
            recuiredXp *= 1.15f;
        }
    }
}
