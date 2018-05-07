using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerSpawn : MonoBehaviour {

    // Inspector
    public Speaker speaker;
    public Transform player;

    // Parents
    public Transform spParent;

    // Chunk to control amount of speakers/pickups
    public int chunk = 100;

    // Private
    private int speakerCount = 0;
    private const int offset = 7;

    private bool gameStart = false;

    private Vector2 speakerPos;

    private float newY;
    private float error = 0;

    // List to track all previous Y values of other speakers
    private List<float> previousY = new List<float>();
	
	// Update is called once per frame
	void Update () {
        FindSpeakerPos();

        // Is the player close enough to the top that a new chunk must be formed?
        float error = chunk - player.position.y;

        if (error <= 25)
        {
            chunk += 100;
            speakerCount = 0;

            previousY.Clear();

            FindSpeakerPos();
        }
    }

    // Speaker Instantiation
    void FindSpeakerPos()
    {
        if (!gameStart)
        {

            for (int i = 0; i < chunk; i += 10)
            {
                speakerPos = new Vector2(Random.Range(-3, 3), Random.Range((chunk - 100), chunk));

                // If a the Y value is in a certain range then break and find a new random position
                if (!CheckSpeakerPos())
                {
                    break;
                }

                previousY.Add(speakerPos.y);

                Speaker prefab = Instantiate(speaker, speakerPos, Quaternion.identity);
                prefab.transform.parent = spParent;

                speakerCount++;

                if (speakerCount >= 10)
                {
                    gameStart = true;
                }
                
            }
        }

        if (gameStart)
        {
            for (int i = chunk - 100; i < chunk; i += 10)
            {
                speakerPos = new Vector2(Random.Range(-3, 3), Random.Range((chunk - 100), chunk));

                if (!CheckSpeakerPos())
                {
                    break;
                }

                previousY.Add(speakerPos.y);

                Speaker prefab = Instantiate(speaker, speakerPos, Quaternion.identity);

                prefab.transform.parent = spParent;

                speakerCount++;

                if (speakerCount >= 10)
                {
                    return;
                }

            }
        }

    }

    bool CheckSpeakerPos()
    {
        for (int j = 0; j < previousY.Count; j++)
        {
            if (speakerPos.y <= previousY[j] + offset && speakerPos.y >= previousY[j] - offset)
            {
                return false;
            }
        }
        
        return true;
    }


}
