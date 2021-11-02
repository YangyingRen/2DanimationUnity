using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusPoint : MonoBehaviour
{
    public GameObject Point;
    public Text Score;
    private int i=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPoint(){
    i+=100;
    Score.text=i.ToString();
    Point.SetActive(true);
    }

    public void PointOut(){
    Point.SetActive(false);

    gameObject.SetActive(false);

    }
}
