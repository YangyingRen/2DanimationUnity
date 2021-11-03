using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mole : MonoBehaviour
{
    public GameObject HitButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void MoleShowsUp(){
        transform.GetChild(0).gameObject.SetActive(true);
        HitButton.SetActive(true);
        
    }
    public void MoleShowOff(){
        gameObject.SetActive(false);
    }
    public void HitUnable(){
        HitButton.SetActive(false);
    }
}
