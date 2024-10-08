using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private LevelHandeler playerLevel;

    private GameObject playerObj;

    public float enemyHealth;
    public float maxEnemyHealth;
    public float enemyDamage;


    private void Awake()
    {
        playerObj = GameObject.Find("playerObj");
        playerLevel = playerObj.GetComponent<LevelHandeler>();
    }
    private void Update()
    {
        if (enemyHealth <= 0)
        {
            playerLevel.currentXp += 3;
            Destroy(gameObject);
        }
    }
}
