using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour {

    public Sprite[] cloudSprites;

    public Sprite getCloudSprite()
    {
        return cloudSprites[Random.Range(0, cloudSprites.Length - 1)];
    }

}
