using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//has functions to set ball type, detect collisions, and destroy ball instance
public class Ball : MonoBehaviour
{
    public bool hitGround = false;
    public bool hitPlayer = false;
    private float velocity = 0;

    public float CreateBall() //returns velocity according to randomly generated color
    {
        string jsonText = Resources.Load<TextAsset>("Ball").ToString();
        BallType ballData = BallType.CreateFromJSON(jsonText);

        float colorRange = Random.Range(0.0f, 1.0f);
        if (colorRange < 0.33)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            velocity = ballData.red;
           
        }
        else if (colorRange > 0.66)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            velocity = ballData.blue;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            velocity = ballData.green;
        }
        return velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plane")
        {
            hitGround = true;
        }
        else if(collision.gameObject.name == "Player")
        {
            hitPlayer = true;
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    }
}
