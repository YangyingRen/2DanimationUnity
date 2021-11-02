using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusPoint : MonoBehaviour
{
    public GameObject Point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPoint(){
     Point.SetActive(true);
    }

    public void PointOut(){
    Point.SetActive(false);

    gameObject.SetActive(false);

    }
}
