using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerCursor : MonoBehaviour
{
    private Animator anim;
    public RectTransform Cursor;
    public GameObject Bonus;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.anchoredPosition = new Vector2(mousePos.x*100f, mousePos.y*100f);

        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Hit",true);
        }
    }
    public void GetScore(){

        Bonus.SetActive(true);
    }

    public void FinishHit(){
        anim.SetBool("Hit",false);

    }

}
