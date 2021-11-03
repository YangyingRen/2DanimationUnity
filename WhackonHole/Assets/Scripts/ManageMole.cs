using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMole : MonoBehaviour
{
    public GameObject[] Moles;
    private int len;
    public float time=0;
    // Start is called before the first frame update
    void Start()
    {
       len=Moles.Length; 
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time>4f){
            ShowMole();
            time=0;
        }
        
    }

    void ShowMole(){
        int i=Random.Range(0,len);
        Moles[i].SetActive(true);
    }
}
