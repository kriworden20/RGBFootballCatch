using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallShooter : MonoBehaviour
{
    public Rigidbody ballPrefab;
    public Transform spawner;
    public Ball b;
    public int score = 0;
    public int ballsCaught = 0;
    //public GameObject scoreText = scoreText.GetComponent<Text>();
    //= scoreText.GetComponent<Text>();

    // Start is called before the first frame update
    void Start()
    {
        ShootBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (b == null)
        {

        }
        else if (b.hitPlayer == true)
        {
            b.DestroyBall();
            ShootBall();
            ballsCaught++;
            AddScore();
            
        }
        else if(b.hitGround == true)
        {
            //end game

            b.DestroyBall();
            Debug.Log(score);
        }
    }

    public void ShootBall()
    {
        Rigidbody ballInstance = Instantiate(ballPrefab, spawner.position, spawner.rotation);
        b = ballInstance.GetComponent<Ball>();

        string jsonText = Resources.Load<TextAsset>("Ball").ToString();
        BallVelocity ballData = BallVelocity.CreateFromJSON(jsonText);

        float colorRange = Random.Range(0.0f, 1.0f);
        if (colorRange < 0.33)
        {
            ballInstance.AddForce(spawner.up * ballData.red);
            ballInstance.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (colorRange > 0.66)
        {
            ballInstance.AddForce(spawner.up * ballData.blue);
            ballInstance.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            ballInstance.AddForce(spawner.up * ballData.green);
            ballInstance.GetComponent<Renderer>().material.color = Color.green;
        }
        
    }

    public void AddScore()
    {
        if(ballsCaught % 5 == 0)
        {
            score += ballsCaught / 5;
        }
        else
        {
            score += ballsCaught / 5 + 1;
        }
        //Display score to UI
        UpdateScore();
    }

    public void UpdateScore()
    {
        //scoreText.GetComponent<Text>().text = "Score: " + score + "\nHigh Score: 0";
    }
}
