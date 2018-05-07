using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    public SpriteRenderer renderer;
    public SpriteManager spriteManager;

    private float speed;
    private Vector3 move;
    private float startTime;

	// Use this for initialization
	void Awake () {
        startTime = Time.time;

        Sprite sprite = spriteManager.getCloudSprite();

        renderer.sprite = sprite;

        speed = Random.Range(0.01f, 0.07f);

        if (transform.position.x >= -4 && transform.position.x <= -3)
        {
            move = new Vector3(speed, 0, 0);
        }
        else if (transform.position.x <= 4 && transform.position.x >= 3)
        {
            move = new Vector3(-speed, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += move;

        if (Time.time - startTime >= 16)
        {
            Destroy(gameObject);
        }
	}
}
