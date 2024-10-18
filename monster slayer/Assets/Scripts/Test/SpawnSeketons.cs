using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeketons : MonoBehaviour
{
    public GameObject skeletonPreFab;
    public Transform spawnLocation;
    private float spawnchanse;
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
        spawnchanse = UnityEngine.Random.Range(1f, 100f);
        spawnchanse = Mathf.Clamp(spawnchanse, 1f, 100f);
        if (spawnchanse >= 3 && spawnchanse <= 4)
        {
            GameObject SkeletonSpawner = Instantiate(skeletonPreFab, spawnLocation.position, spawnLocation.rotation);
        }
    }
}
