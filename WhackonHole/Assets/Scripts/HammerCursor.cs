using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCursor : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        if (Input.GetMouseButton(0))
        {
            anim.Play("CursorHit");
        }
    }
}
