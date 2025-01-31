using System.Collections;
using System.Collections.Generic;
using Enemys;
using player;
using UnityEngine;

public class HolyShot1 : MonoBehaviour
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
            other.gameObject.GetComponent<PlayerStats>().playerHealth -= 1;
            print(other.gameObject.GetComponent<PlayerStats>().playerHealth);
            Destroy(gameObject);
        }
    }
}
