using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    [SerializeField] Camera cam;

    private Vector2 mouseCursorPosition;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseCursorPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPosition;

        
    }

    
}

