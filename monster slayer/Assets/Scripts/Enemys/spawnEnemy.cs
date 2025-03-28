using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawnEnemy : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPositionOne;
    public Transform spawnPositionTwo;

    public GameObject Enemy;
    
    private float spawnPositionX;
    private float spawnPositionZ;

    public EnemyFactory enemyFactory;

    private void Start()
    {
        enemyFactory.InitFactory();
    }

    private void FixedUpdate()
    {
            if(CheckSpawnPossiblity()) spawningEnemy();
    }

    void findSpawnPosition()
    {
        spawnPositionX = Random.Range(spawnPositionOne.position.x , spawnPositionTwo.position.x);
        spawnPositionZ = Random.Range(spawnPositionOne.position.z, spawnPositionTwo.position.z);
        print(spawnPositionX);
        print(spawnPositionZ);
    }

    void spawningEnemy()
    {
        print("helads");
        GameObject enemy = enemyFactory.OnSpawnTriggered();
        
        print(enemy);
        if (enemy != null)
        {
            print("hello");
            GameObject SkeletonSpawner = Instantiate(enemy,
                new Vector3(spawnPositionX, transform.position.y, spawnPositionZ), Quaternion.identity);
        }
    }

    bool CheckSpawnPossiblity()
    {
        findSpawnPosition();
        float distance = Vector2.Distance (new Vector2(spawnPositionX, spawnPositionZ), new Vector2(player.transform.position.x, player.transform.position.z));

        if (distance < 10)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
