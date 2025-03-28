using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemys;
using player;

public class FireBallDmg : MonoBehaviour
{
    public CreateStatsinventory Statsinventory;
    private string _tagToDamage = "Enemy";

    private void Start()
    {
        //fix so that the statsinventory is not null
        Statsinventory = GameObject.Find("Inventory").GetComponent<CreateStatsinventory>();
    }

    public void Init(string tagToDamage)
    {
        _tagToDamage = tagToDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Enemy" == _tagToDamage && other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyStats>().enemyHealth -= 1 + Statsinventory.magicalPowerInt;
            Destroy(gameObject);
        }

        if ("Player" == _tagToDamage && other.gameObject.tag == "Player")
        {
            PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
            player.setHealth(player.getPlayerHealth() - 1);
            Destroy(gameObject);
        }
    }
}
