using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] DynamicObjectConfig DefaultTestSpawn;
    [SerializeField] List<GameObject> SpawnPositions = new List<GameObject>();

    private void Start()
    {
        DynamicObject newObject = DynamicObject.CreateDynamicObject(DefaultTestSpawn);

        GameObject randPosition = SpawnPositions[Random.Range(0, SpawnPositions.Count)];
        newObject.transform.position = randPosition.transform.position;
    }


}
