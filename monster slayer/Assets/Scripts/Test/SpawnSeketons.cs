using UnityEngine;

namespace Test
{
    public class SpawnSeketons : MonoBehaviour
    {
        public GameObject skeletonPreFab;
        public Transform spawnLocation;
        private float spawnchanse;
        
        public bool canSpawn = true;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            spawnchanse = UnityEngine.Random.Range(1f, 100f);
            spawnchanse = Mathf.Clamp(spawnchanse, 1f, 100f);
            if (spawnchanse >= 3 && spawnchanse <= 4 && canSpawn == true)
            {
                GameObject SkeletonSpawner = Instantiate(skeletonPreFab, spawnLocation.position, spawnLocation.rotation);
            }
        }
    }
}
