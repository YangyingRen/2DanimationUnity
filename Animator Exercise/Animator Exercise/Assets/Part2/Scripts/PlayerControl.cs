using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    int hmove = 0, vmove = 0; //to store the current move direction
    float moveSpeed = 5f;
    bool dead = false;

    
    void Update()
    {
        if (!dead)
        {
            CheckControls();
            DoMovement();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dead = true;
        }
    }

    private void CheckControls()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vmove = 1;
            hmove = 0;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vmove = -1;
            hmove = 0;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            vmove = 0;
            hmove = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            vmove = 0;
            hmove = 1;
        }
    }

    private void DoMovement()
    {
        transform.Translate(new Vector3(hmove * moveSpeed, vmove * moveSpeed, 0) * Time.deltaTime);
    }
}
