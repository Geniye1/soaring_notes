using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampColliders : MonoBehaviour {

    public Transform player;

	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.y = player.position.y;
        transform.position = pos;
	}
}
