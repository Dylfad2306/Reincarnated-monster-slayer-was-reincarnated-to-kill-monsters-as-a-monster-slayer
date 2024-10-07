using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDameger : MonoBehaviour
{
    public PlayerStats playerStats;
    public EnemyStats enemyStats;
    public playerAnimationController playerAnimationController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hello");
        if (other.gameObject.tag == "Enemy")
        {
            print("Hello ita me merbio");
            enemyStats.enemyHealth -= playerStats.playerDamage;
        }
    }

    

}
