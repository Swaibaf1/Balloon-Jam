using System.Collections.Generic;
using UnityEngine;


public enum E_DynamicObjectType
{
    Threat,
    Aid
}

public class DynamicObject : MonoBehaviour
{
    public DynamicObjectConfig Config;
    public static List<DynamicObject> s_SpawnedObjects = new List<DynamicObject>();
    public GameObject SpawnedObject;

    [SerializeField] Sprite SpawnDestroyer;

    public static DynamicObject CreateDynamicObject(DynamicObjectConfig config)
    {
        // create new dynamic object and track it- what type spawns will be handled in a spawn manager 
        DynamicObject newObject = new GameObject().AddComponent<DynamicObject>();
        newObject.Config = config;
        newObject.SpawnedObject = GameObject.Instantiate(config.Prefab, newObject.transform);
        s_SpawnedObjects.Add( newObject );
        return newObject;
    }

    public void OnDestroy()
    {
        if (SpawnedObject == null)
        {
            return;
        }

        s_SpawnedObjects.Remove(this);
        Destroy(SpawnedObject);

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x -= Config.Speed * Time.deltaTime;
        transform.position = newPosition;

      

    }
}
