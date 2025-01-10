using System;
using player;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ForceMode;

public class FireBall : ActiveAbility, IAbility
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
            SetAbilityInformation("FireBall", "ball of fire", 1, 2, 0, "Active");
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
            else
            {
                print("FireBall on cooldown");
            }
           
        }
    }
