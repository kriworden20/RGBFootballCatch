using UnityEngine;

[System.Serializable]
public class BallType
{
    public float red;
    public float green;
    public float blue;

    public static BallType CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<BallType>(jsonString);
    }

}
