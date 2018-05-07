using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public float classicalForce;
    public float symphonicForce;
    public float rockForce;
    public float metalForce;

    public enum Music
    {
        Classical,
        Symphonic,
        Rock,
        Metal
    };

    public static Music State;

    public Music GetState()
    {
        return State;
    }

    public void ChangeState(Music state)
    {
        State = state;
        Speaker[] speakers = FindObjectsOfType<Speaker>();

        foreach(Speaker speaker in speakers)
        {
            speaker.SpeakerChange();
        }
    }

    public float ChangeForce(Music music)
    {
        switch (music)
        {
            case Music.Classical:
                return classicalForce;
                break;
            case Music.Symphonic:
                return symphonicForce;
                break;
            case Music.Rock:
                return rockForce;
                break;
            case Music.Metal:
                return metalForce;
                break;
            default:
                return classicalForce;
        }

    }

}
