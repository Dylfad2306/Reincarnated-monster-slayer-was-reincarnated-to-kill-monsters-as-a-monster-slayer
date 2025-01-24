using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemys;

public class RockShotDmg : MonoBehaviour
{
    public CreateStatsinventory Statsinventory;
    private string _tagToDamage = "Enemy";

    private void Start()
    {
        //fix so that the statsinventory is not null
        Statsinventory = GameObject.Find("Inventory").GetComponent<CreateStatsinventory>();
        print(_tagToDamage);
    }

    public void Init(string tagToDamage)
    {
        _tagToDamage = tagToDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(_tagToDamage);
        print(other.gameObject.tag);
        if (other.gameObject.tag == _tagToDamage)
        {
            other.gameObject.GetComponent<EnemyStats>().enemyHealth -= 1 + Statsinventory.magicalPowerInt;
            Destroy(gameObject);
        }
    }
}
