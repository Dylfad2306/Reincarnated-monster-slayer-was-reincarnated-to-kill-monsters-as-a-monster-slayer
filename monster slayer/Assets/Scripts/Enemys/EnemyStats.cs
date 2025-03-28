using player;
using UnityEngine;

namespace Enemys
{
    public class EnemyStats : MonoBehaviour
    {
        private LevelHandeler playerLevel;

        private GameObject playerObj;

        public float enemyHealth;
        public float maxEnemyHealth;
        public float enemyDamage;
        [SerializeField] private int maxCount;

        [SerializeField]
        private EnemyFactory enemyFactory;

        public int GetMaxCount()
        {
            return maxCount;
        }
    
        private void Awake()
        {
            playerObj = GameObject.Find("playerObj");
            playerLevel = playerObj.GetComponent<LevelHandeler>();
        }
        private void Update()
        {
            if (enemyHealth <= 0)
            {
                playerLevel.currentXp += 3;
                Destroy(gameObject);
                enemyFactory.DecreaseSpawnCount();
            }
        }
    }
}
