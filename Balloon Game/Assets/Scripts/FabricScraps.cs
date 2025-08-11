using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FabricScraps : MonoBehaviour
{
    [SerializeField] public List<Sprite> FabricSprites = new List<Sprite>();


    private void Start()
    {
        Sprite randSprite = FabricSprites[Random.Range(0, FabricSprites.Count)];

        GetComponent<SpriteRenderer>().sprite = randSprite;
    }

}
