using UnityEngine;

[CreateAssetMenu(fileName = "NewDynamicObjectConfig", menuName = "ScriptableObjects/DynamicObjectConfig", order = 1)]

public class DynamicObjectConfig : ScriptableObject
{
    public int Speed;
    public E_DynamicObjectType ObjectType;
    public GameObject Prefab;
}