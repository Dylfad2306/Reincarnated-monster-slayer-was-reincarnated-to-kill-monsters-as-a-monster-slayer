using System.Collections;
using System.Collections.Generic;
using player;
using Unity.Mathematics;
using UnityEngine;


   public class RockShot : ActiveAbility, IAbility
   {
       public GameObject abilityPrefab;
       public Transform Spawnpoint;
       public Transform playerView;
       public float BallDrop = 0.1f;
       public float BallSpeed = 50f;
       private float ablilityCooldown = 1;
       
       public PlayerStats playerStats;
       protected override void OnStartAbility()
       {
           SetAbilityInformation("RockShot", "shouts a rock bullet", 1, 2, 0, "Active", 3);
       }
       private void Awake()
       {
           playerStats = GameObject.Find("playerObj").GetComponent<PlayerStats>();
       }

       public void ActivateAbility()
       {
           if (ablilityCooldown <= Time.time)
           {
               GameObject RockShot = Instantiate(abilityPrefab, _Spawnpoint.position, quaternion.identity);
               RockShot.GetComponent<RockShotDmg>().Init(_tagToDamage);

               if (gameObject.tag == "Player")
               {
                   playerStats.playermana -= 10;
               }
               
               RockShot.GetComponent<Rigidbody>().velocity = playerView.forward * BallSpeed;
                         
               Destroy(RockShot, 5f);  
               ablilityCooldown = Time.time + 1;
           }
       }

       public override void Init(string tagToDamage, Transform Spawnpoint)
       {
           base.Init(tagToDamage, Spawnpoint);
           abilityPrefab = Resources.Load("active/T1/RockShot/RockShotprefab") as GameObject;
           _Spawnpoint = Spawnpoint;
           playerView = Spawnpoint;
       }
   }

