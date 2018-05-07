using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour {

    public Camera mainCamera;
    public GameObject cloud;
    //public GameObject cloudParent;

    private float xPos;
    private float yPos;

	// Use this for initialization
	void Start () {
        SpawnClouds();
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void SpawnClouds()
    {
        float side = Random.Range(0f, 1f);
      
        if (side <= 0.5)
        { 
            xPos = -4f;
        }
        else
        {
            xPos = 4f;   
        }

        float yPos = Random.Range(-5f, 5f);
        print(yPos);

        Instantiate(cloud, new Vector3(xPos, yPos, -1), Quaternion.identity);

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        SpawnClouds();
    }

}
