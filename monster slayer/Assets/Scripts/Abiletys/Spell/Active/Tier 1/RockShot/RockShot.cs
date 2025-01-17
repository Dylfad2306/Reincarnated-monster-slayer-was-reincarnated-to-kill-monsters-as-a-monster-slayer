using System.Collections;
using System.Collections.Generic;
using player;
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
       public void ActivateAbility()
       {
           if (ablilityCooldown <= Time.time)
           {
               GameObject fireball = Instantiate(abilityPrefab, Spawnpoint.position, transform.rotation);
                         
               playerStats.playermana -= 10; 
                         
               fireball.GetComponent<Rigidbody>().velocity = playerView.forward * BallSpeed;
                         
               Destroy(fireball, 5f);  
               ablilityCooldown = Time.time + 1;
           }
       }
   }

