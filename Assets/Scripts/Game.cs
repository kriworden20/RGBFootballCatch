using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Game: manages game play and UI
public class Game : MonoBehaviour
{
    //Attach gameobjects
    public Rigidbody ballPrefab;
    public Transform spawner;
    public GameObject scoreDisplay;
    public GameObject menuDisplay;
    public GameObject panel;


    private ScoreScript s;
    private MenuScript m;
    private Ball b;
    private int score = 0;
    private int highScore = 0;
    private int ballsCaught = 0;
    private bool gameOn = false;

    void Start()
    {
        panel.SetActive(false);
        Load(); //load save data
        s = scoreDisplay.GetComponent<ScoreScript>();
        m = menuDisplay.GetComponent<MenuScript>();
        m.UpdateHighScore(highScore); //set high score text
        panel.SetActive(true);
    }

    void Update()
    {
        if(!gameOn)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                score = 0;
                ballsCaught = 0;
                s.UpdateScore(score); //reset score text
                panel.SetActive(false);
                gameOn = true;
                ShootBall();
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                Save(); //save high score
                Application.Quit();
            }
        }
        else //game is on
        {
            proceedGame();
        }
    }

    public void ShootBall()
    {
        Rigidbody ballInstance = Instantiate(ballPrefab, spawner.position, spawner.rotation);
        b = ballInstance.GetComponent<Ball>();
        ballInstance.AddForce(spawner.up * b.CreateBall());
    }

    public void AddScore()
    {
        if (ballsCaught % 5 == 0)
        {
            score += ballsCaught / 5;
        }
        else
        {
            score += ballsCaught / 5 + 1;
        }
        //update score
        s.UpdateScore(score);
    }

    public void proceedGame()
    {
       if (b.hitPlayer == true)
        {
            ballsCaught++;
            AddScore();
            b.DestroyBall();
            ShootBall();
        }
        else if (b.hitGround == true)
        {
            b.DestroyBall();
            gameOn = false;
            if(highScore < score)
            {
                highScore = score;
                m.UpdateHighScore(highScore);
            }
            panel.SetActive(true);
        }
    }

    public void Save()
    {
        Save save = new Save();
        save.highScore = highScore;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            highScore = save.highScore;

        }
        else
        {
            Debug.Log("no game saved");
        }
    }
}
