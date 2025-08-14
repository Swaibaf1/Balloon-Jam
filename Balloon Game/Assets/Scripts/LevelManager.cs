using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] DynamicObjectConfig FabricSpawn;
    [SerializeField] DynamicObjectConfig ThreatSpawn;
    [SerializeField] List<GameObject> SpawnPositions = new List<GameObject>();

    [SerializeField] HashSet<int> usedPositions = new HashSet<int>();


    public float spawnTimer;
    public int spawnInterval = 5;
    public int minSpawnCount = 1;
    public int maxSpawnCount = 3;


    private void Start()
    {
        
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            //SpawnThreat();

            SpawnThreatNew();
        }

    }

    private void SpawnFabric()
    {
        for (int i = 0; i < SpawnPositions.Count; i++)
        {
            DynamicObject newObject = DynamicObject.CreateDynamicObject(FabricSpawn);

            GameObject randPosition = SpawnPositions[Random.Range(0, SpawnPositions.Count)];
            newObject.transform.position = randPosition.transform.position;

            spawnTimer = 0;
        }
    }

    private void SpawnThreat()
    {
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);
        
        for (int i = 0; i < SpawnPositions.Count; i++)
        {
            DynamicObject newObject = DynamicObject.CreateDynamicObject(ThreatSpawn);

            GameObject randPosition = SpawnPositions[Random.Range(0, SpawnPositions.Count)];
            newObject.transform.position = randPosition.transform.position;

            spawnTimer = 0;
        }
        
    }

    private void SpawnThreatNew()
    {
        if(SpawnPositions.Count <= 0)
        {
            return;
        }

        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);
        for(int i = 0; i < spawnCount; i++)
        {
            int randomIndex;


            for (int y = 0; y < 10; y++)
            {
                randomIndex = Random.Range(0, SpawnPositions.Count);

                if(!usedPositions.Contains(randomIndex))
                {
                    usedPositions.Add(randomIndex);
                    break;
                }

            }

            DynamicObject newObject = DynamicObject.CreateDynamicObject(ThreatSpawn);

            GameObject randPosition = SpawnPositions[Random.Range(0, SpawnPositions.Count)];
            newObject.transform.position = randPosition.transform.position;

            spawnTimer = 0;
        }

        
    }


}
