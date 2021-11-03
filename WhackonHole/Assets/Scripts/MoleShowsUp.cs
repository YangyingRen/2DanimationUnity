using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleShowsUp : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NotHit(){
        anim.SetBool("Show",true);
        anim.SetBool("Hit",false);

    }
    public void Finish(){
        anim.SetBool("Show",false);
        anim.SetBool("Hit",false);
    }

    public void Hit(){
        anim.SetBool("Show",false);
        anim.SetBool("Hit",true);
    }
    public void Hide(){
        gameObject.SetActive(false);
    }
}
