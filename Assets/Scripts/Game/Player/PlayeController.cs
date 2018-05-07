using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayeController : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    public MusicManager music;
    public Text scoreText;

    public static bool s_isOnSpeaker = false;
    public static int score = 0;

    private int jumps = 0;
    private int playerLayer;

    private void Start()
    {
        playerLayer = ~(LayerMask.GetMask("Player"));

        UpdateScore();
    }

    // Update is called once per frame
    void FixedUpdate () {

        /// Moving Right
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x >= 0)
            {
                rb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            }
            else if (rb.velocity.x < 0)
            {
                rb.AddForce(Vector2.right * speed * 1 * Time.deltaTime, ForceMode2D.Impulse);
            }  
        }

        /// Moving Left
        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x >= 0)
            {
                rb.AddForce(Vector2.left * speed * 1 * Time.deltaTime, ForceMode2D.Impulse);
            }
            else if (rb.velocity.x < 0)
            {
                rb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        /// Changing Music State
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            music.ChangeState(MusicManager.Music.Classical);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            music.ChangeState(MusicManager.Music.Symphonic);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            music.ChangeState(MusicManager.Music.Rock);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            music.ChangeState(MusicManager.Music.Metal);
        }

        /// Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GroundCheck();
            if (jumps < 2)
            {
                rb.AddForce(Speaker.launchForce, ForceMode2D.Impulse);
                jumps++;
            }
            else
            {
                return;
            }
        }
    }

    void GroundCheck()
    {
        Vector2 plPos = transform.position;
        plPos.y -= 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(plPos, Vector2.down, 1f, playerLayer);

        Debug.DrawRay(plPos, Vector2.down, Color.red, 100000);

        if (hit)
        {
            if (hit.transform.tag == "Speaker" && jumps != 0)
            { 
                jumps = 0;
            }
        }
    }

    public void UpdateScore()
    {
        print("Updating score...");
        scoreText.text = "Score : " + score;
        print("Score updated!");
    }
}
