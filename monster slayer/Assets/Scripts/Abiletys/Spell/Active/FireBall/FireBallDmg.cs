using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemys;

public class FireBallDmg : MonoBehaviour
{
    public CreateStatsinventory Statsinventory;

    private void Start()
    {
        //fix so that the statsinventory is not null
        Statsinventory = GameObject.Find("Inventory").GetComponent<CreateStatsinventory>();
        print(Statsinventory.magicalPowerInt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print(Statsinventory.magicalPowerInt);
            other.gameObject.GetComponent<EnemyStats>().enemyHealth -= 1 + Statsinventory.magicalPowerInt;
            Destroy(gameObject);
        }
    }
}
