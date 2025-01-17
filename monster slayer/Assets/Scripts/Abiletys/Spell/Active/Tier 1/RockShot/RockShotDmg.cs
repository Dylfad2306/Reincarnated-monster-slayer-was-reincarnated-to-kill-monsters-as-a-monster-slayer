using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemys;

public class RockShotDmg : MonoBehaviour
{
    public CreateStatsinventory Statsinventory;

    private void Start()
    {
        //fix so that the statsinventory is not null
        Statsinventory = GameObject.Find("Inventory").GetComponent<CreateStatsinventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyStats>().enemyHealth -= 2 + Statsinventory.magicalPowerInt;
            Destroy(gameObject);
        }
    }
}
