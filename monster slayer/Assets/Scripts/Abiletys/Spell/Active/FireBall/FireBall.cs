using System;
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
        protected override void OnStartAbility()
        {
            SetAbilityInformation("FireBall", "ball of fire", 1, 2, 0, "Active");
        }
        public void ActivateAbility()
        { 
           GameObject fireball = Instantiate(abilityPrefab, Spawnpoint.position, transform.rotation);
           
           fireball.GetComponent<Rigidbody>().velocity = playerView.forward * BallSpeed;
           
           Destroy(fireball, 5f);
        }
    }
