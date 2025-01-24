using System;
using System.Collections.Generic;
using System.Reflection;
using player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemys
{
    public class EnemyAi : MonoBehaviour
    {
        private PlayerStats PlayerStats;
        public EnemyStats EnemyStats;
        public EnemyHealthBar EnemyHealthBar;
        public enemyspellselect enemyspells;

        public NavMeshAgent agent;

        private Transform player;
        private GameObject playerObj;

        public LayerMask whatIsGround, whatIsPlayer;

        //Patroling
        public Vector3 walkPoint;
        bool walkPointSet;
        public float walkPointRange;

        //Attacking
        public float timeBetweenAttacks;
        bool alreadyAttacked;

        //State
        public float sightRange, attackRange, spellRange;
        public bool playerInSightRange, playerInAttackRange, playerInSpellRange;
        
        
        private void Awake()
        {
            EnemyHealthBar.UpdateHealthBar(EnemyStats.enemyHealth, EnemyStats.maxEnemyHealth);
            player = GameObject.Find("playerObj").transform;
            playerObj = GameObject.Find("playerObj");
            PlayerStats = playerObj.GetComponent<PlayerStats>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            EnemyHealthBar.UpdateHealthBar(EnemyStats.enemyHealth, EnemyStats.maxEnemyHealth);

            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            playerInSpellRange = Physics.CheckSphere(transform.position, spellRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange && !playerInSpellRange) Patroling();
            if (playerInSightRange && !playerInAttackRange && !playerInSpellRange) ChasePlayer();
            if (playerInSightRange && !playerInAttackRange && playerInSpellRange)
            {
                SpellChast(); 
                ChasePlayer();
            }
            if (playerInSightRange && playerInAttackRange && playerInSpellRange) AttackPlayer();
        }

        private void Patroling()
        {
            if (!walkPointSet) SearchWalkPoint();

            if(walkPointSet)
            {
                agent.SetDestination(walkPoint);
            }

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }

        void SearchWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            {
                walkPointSet = true;
            }
        }

        private void ChasePlayer()
        {
            agent.SetDestination(player.position);
        }

        private void SpellChast()
        {
            int SpellOrNot = Random.Range(0, 1);

            if (SpellOrNot == 0)
            {
                if (enemyspells.addedAbilities.Count != 0)
                {
                    // set a cooldown
                    int randomIndex = Random.Range(0, enemyspells.addedAbilities.Count);
                    MonoBehaviour randomScript = enemyspells.addedAbilities[randomIndex];
                    randomScript.GetType().GetMethod("ActivateAbility").Invoke(randomScript, null);
                }

            }
            // activateAbilities
        }

        private void AttackPlayer()
        {
            agent.SetDestination(transform.position);

            transform.LookAt(player);

            if (!alreadyAttacked)
            {

                PlayerStats.playerHealth -= EnemyStats.enemyDamage;

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }

        private void ResetAttack()
        {
            alreadyAttacked = false;
        }
    }
}
