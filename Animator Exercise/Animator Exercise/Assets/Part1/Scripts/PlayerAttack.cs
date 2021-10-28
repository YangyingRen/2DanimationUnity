using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    AudioSource sound;
   
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        //do attack stuff
    }

    public void PlayAttackSFX()
    {
        sound.Play();
    }
}
