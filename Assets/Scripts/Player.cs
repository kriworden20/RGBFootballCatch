using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    void Check()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("isRun", true);
            anim.SetBool("isBackwards", false);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            anim.SetBool("isRun", false);

        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetBool("isBackwards", true);
            anim.SetBool("isRun", false);
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            anim.SetBool("isBackwards", false);
        }
    }
}
