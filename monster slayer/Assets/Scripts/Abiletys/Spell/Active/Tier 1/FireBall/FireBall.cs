using System;
using player;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ForceMode;

public class FireBall : ActiveAbility, IAbility
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
            SetAbilityInformation("FireBall", "ball of fire", 1, 2, 0, "Active", 3);
        }

        private void Awake()
        {
            playerStats = GameObject.Find("playerObj").GetComponent<PlayerStats>();
        }

        public void ActivateAbility()
        {
            if (ablilityCooldown <= Time.time)
            {
              GameObject fireball = Instantiate(abilityPrefab, _Spawnpoint.position, transform.rotation);
              fireball.GetComponent<FireBallDmg>().Init(_tagToDamage);

              if (gameObject.tag == "Player")
              {
                  playerStats.playermana -= 10;
              }
                         
                         
                fireball.GetComponent<Rigidbody>().velocity = playerView.forward * BallSpeed;
                         
                Destroy(fireball, 5f);  
                ablilityCooldown = Time.time + 1;
            }
        }

        public override void Init(string tagToDamage, Transform Spawnpoint)
        {
            base.Init(tagToDamage, Spawnpoint);
            abilityPrefab = Resources.Load("active/T1/fireball/fireballPreFab") as GameObject;
            _Spawnpoint = Spawnpoint;
            playerView = Spawnpoint;
        }
    }
