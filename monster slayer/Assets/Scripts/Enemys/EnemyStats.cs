using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public LevelHandeler levelHandeler;

    public float enemyHealth;
    public float maxEnemyHealth;
    public float enemyDamage;

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            levelHandeler.currentXp += 3;
            Destroy(gameObject);
        }
    }
}
