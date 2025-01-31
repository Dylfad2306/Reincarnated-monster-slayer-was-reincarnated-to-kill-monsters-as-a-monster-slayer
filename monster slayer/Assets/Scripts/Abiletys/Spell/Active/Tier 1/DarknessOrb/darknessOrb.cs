using System.Collections;
using System.Collections.Generic;
using player;
using UnityEngine;

public class darknessOrb : ActiveAbility
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
        SetAbilityInformation("darknessOrb", "shouts a rock bullet", 1, 2, 0, "Active", 3);
    }
    private void Awake()
    {
        playerStats = GameObject.Find("playerObj").GetComponent<PlayerStats>();
    }

    public void ActivateAbility()
    {
        if (ablilityCooldown <= Time.time)
        {
            GameObject darknessOrb = Instantiate(abilityPrefab, _Spawnpoint.position, transform.rotation);
            darknessOrb.GetComponent<darknessOrbDmg>().Init(_tagToDamage);

            if (gameObject.tag == "Player")
            {
                playerStats.playermana -= 10;
            }
                         
                         
            darknessOrb.GetComponent<Rigidbody>().velocity = playerView.forward * BallSpeed;
                         
            Destroy(darknessOrb, 5f);  
            ablilityCooldown = Time.time + 1;
        }
    }

    public override void Init(string tagToDamage, Transform Spawnpoint)
    {
        base.Init(tagToDamage, Spawnpoint);
        abilityPrefab = Resources.Load("active/T1/darknessOrb/darknessOrbPreFab") as GameObject;
        _Spawnpoint = Spawnpoint;
        playerView = Spawnpoint;
    }
}
