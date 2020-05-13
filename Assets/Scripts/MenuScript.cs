using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI menuText;

    // Start is called before the first frame update
    void Start()
    {
        menuText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHighScore(int score)
    {
        menuText.text = "   High Score: " + score + "\n   Space Bar: Play\n   Esc: Quit";
    }
}
