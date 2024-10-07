using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeketons : MonoBehaviour
{
    public GameObject skeletonPreFab;
    public Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject SkeletonSpawner = Instantiate(skeletonPreFab, spawnLocation.position, spawnLocation.rotation);
        }
    }
}
