/*
using System.Collections;
using System.Collections.Generic;
*/
using UnityEngine;

[System.Serializable]
public class BallVelocity
{
    public float red;
    public float green;
    public float blue;

    /*
    public void Ball ()
    {
        string jsonTextFile = Resources.Load<TextAsset>("Ball");
        Ball ballData = JsonUtility.FromJson<Ball>(jsonTextFile);
        velocity = ballData.velocity;
        color = ballData.color;
    }
    */
    public static BallVelocity CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<BallVelocity>(jsonString);
    }

}
