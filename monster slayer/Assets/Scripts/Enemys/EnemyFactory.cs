using System.Collections;
using System.Collections.Generic;
using Enemys;
using UnityEngine;

public class EnemyInfo
{
    public GameObject prefab;
    public int count;
    public int maxCount;
}

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "ScriptableObjects/EnemyFactory", order = 1)]
public class EnemyFactory : ScriptableObject
{
    public GameObject[] prefabEnemies;

    private List<EnemyInfo> _enemies;

    public int currentSpawnCount = 0;
    public int spawnLimit = 100;

    public void InitFactory()
    {
        currentSpawnCount = 0;
        _enemies = new List<EnemyInfo>();
        foreach (GameObject enemy in prefabEnemies)
        {
            int maxCount = enemy.GetComponent<EnemyStats>().GetMaxCount();
            _enemies.Add(new EnemyInfo() { prefab = enemy, count = 0, maxCount = maxCount });
        }
    }

    public GameObject OnSpawnTriggered()
    {
        Debug.Log(prefabEnemies.Length);
        Debug.Log(spawnLimit);
        Debug.Log(currentSpawnCount);
        if (prefabEnemies.Length > 0 && currentSpawnCount <= spawnLimit)
        {
            int randomIndex = Random.Range(0, _enemies.Count);

            if (_enemies[randomIndex].count < _enemies[randomIndex].maxCount)
            {
                _enemies[randomIndex].count += 1;
                currentSpawnCount++;
                return _enemies[randomIndex].prefab;
            }
        }
        
        return null;
    }
    
    public void DecreaseSpawnCount() => currentSpawnCount--;
    
    //public GameObject GetRandomEnemy() => prefabEnemies[Random.Range(0, prefabEnemies.Length)];
}
