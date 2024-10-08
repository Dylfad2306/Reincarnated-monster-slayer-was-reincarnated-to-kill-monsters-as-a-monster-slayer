using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDameger : MonoBehaviour
{
    public PlayerStats playerStats;
    public playerAnimationController playerAnimationController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyStats>().enemyHealth -= playerStats.playerDamage;
        }
    }

    

}
