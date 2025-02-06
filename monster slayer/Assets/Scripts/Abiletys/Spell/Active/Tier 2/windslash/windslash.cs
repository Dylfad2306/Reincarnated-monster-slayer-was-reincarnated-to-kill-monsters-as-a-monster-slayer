using System.Collections;
using System.Collections.Generic;
using player;
using UnityEngine;

public class windslash : ActiveAbility
{
    public GameObject abilityPrefab;
    public Transform playerView;
    public float BallDrop = 0.1f;
    public float BallSpeed = 50f;
    private float ablilityCooldown = 1;
    private GameObject spellprojectile;
        
        
    private PlayerStats playerStats;
    protected override void OnStartAbility()
    {
        SetAbilityInformation("windslash", "shouts a blade of wind", 2, 5, 0, "Active", 6);
    }
    
    private void Awake()
    {
        playerStats = GameObject.Find("playerObj").GetComponent<PlayerStats>();
    }

    public void ActivateAbility()
    {
        if (ablilityCooldown <= Time.time)
        {
            GameObject windslash = Instantiate(abilityPrefab, _Spawnpoint.position, transform.rotation);
            windslash.GetComponent<windslashDmg>().Init(_tagToDamage);

            if (gameObject.tag == "Player")
            {
                playerStats.playermana -= 10;
            }
                         
                         
            windslash.GetComponent<Rigidbody>().velocity = playerView.forward * BallSpeed;
                         
            Destroy(windslash, 5f);  
            ablilityCooldown = Time.time + 1;
        }
    }

    public override void Init(string tagToDamage, Transform Spawnpoint)
    {
        base.Init(tagToDamage, Spawnpoint);
        abilityPrefab = Resources.Load("active/T2/windslash/windslashPreFab") as GameObject;
        _Spawnpoint = Spawnpoint;
        playerView = Spawnpoint;
    }
}
