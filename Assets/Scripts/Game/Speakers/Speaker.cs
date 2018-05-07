using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour {

    public MusicManager musicManager;

    public static Vector2 launchForce;
    private float force;

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        SpeakerChange();
    }

    public void SpeakerChange()
    {
        if (musicManager.GetState() == MusicManager.Music.Classical)
        {
            force = musicManager.ChangeForce(MusicManager.Music.Classical);
            launchForce = new Vector2(0, force);
        }
        else if (musicManager.GetState() == MusicManager.Music.Symphonic)
        {
            force = musicManager.ChangeForce(MusicManager.Music.Symphonic);
            launchForce = new Vector2(0, force);
        }
        else if (musicManager.GetState() == MusicManager.Music.Rock)
        {
            force = musicManager.ChangeForce(MusicManager.Music.Rock);
            launchForce = new Vector2(0, force);
        }
        else if (musicManager.GetState() == MusicManager.Music.Metal)
        {
            force = musicManager.ChangeForce(MusicManager.Music.Metal);
            launchForce = new Vector2(0, force);
        }
        print("Launch Force: X = " + launchForce.x + "| Y = " + launchForce.y);
    }

}
