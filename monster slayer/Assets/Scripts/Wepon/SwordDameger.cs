using Enemys;
using player;
using UnityEngine;

namespace Wepon
{
    public class SwordDameger : MonoBehaviour
    {
        public PlayerStats playerStats;
        public playerAnimationController playerAnimationController;

        bool isSwinging = false;
        bool hitEnemy = false;

        float attackTimeer;


        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !isSwinging)
            {
                isSwinging = true;
                hitEnemy = true;
                attackTimeer = Time.time + 1f;
            }

            if (isSwinging && Time.time > attackTimeer)
            {
                isSwinging = false;
                hitEnemy = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy" && hitEnemy)
            {
                other.gameObject.GetComponent<EnemyStats>().enemyHealth -= playerStats.playerDamage;
                isSwinging = false;
                hitEnemy = false;
            }
        }

    

    }
}
