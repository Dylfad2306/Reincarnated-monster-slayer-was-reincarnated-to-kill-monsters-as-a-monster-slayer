using System.Collections;
using System.Collections.Generic;
using player;
using UnityEngine;

public class waterball : ActiveAbility, IAbility
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
        SetAbilityInformation("waterball", "shouts a rock bullet", 1, 2, 0, "Active", 3);
    }
    private void Awake()
    {
        playerStats = GameObject.Find("playerObj").GetComponent<PlayerStats>();
    }

    public void ActivateAbility()
    {
        if (ablilityCooldown <= Time.time)
        {
            GameObject waterball = Instantiate(abilityPrefab, _Spawnpoint.position, transform.rotation);
            waterball.GetComponent<waterballDmg>().Init(_tagToDamage);

            if (gameObject.tag == "Player")
            {
                playerStats.playermana -= 10;
            }
                         
                         
            waterball.GetComponent<Rigidbody>().velocity = playerView.forward * BallSpeed;
                         
            Destroy(waterball, 5f);  
            ablilityCooldown = Time.time + 1;
        }
    }

    public override void Init(string tagToDamage, Transform Spawnpoint)
    {
        base.Init(tagToDamage, Spawnpoint);
        abilityPrefab = Resources.Load("active/T1/waterball/WaterBallPreFab") as GameObject;
        _Spawnpoint = Spawnpoint;
        playerView = Spawnpoint;
    }
}
