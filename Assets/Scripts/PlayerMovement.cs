using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   

    
    public float moveSpeed = 5f;
    private float angle;
    private bool isDashButtonDown;
    Vector2 movement;
    Vector2 mousePosition;
    Vector2 lookDirection;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] private float dashAmount = 30f;



    public SimpleTouchController STCLeft;
    public SimpleTouchController STCRight;
    
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //movement.x = STCLeft.GetTouchPosition.x;//sol joystick'in hareketine göre oyuncuyu hareket ettirir
        //movement.y = STCLeft.GetTouchPosition.y;


        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDashButtonDown = true;
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed* Time.fixedDeltaTime);

        lookDirection = mousePosition - rb.position;
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //angle = Mathf.Atan2(STCRight.GetTouchPosition.y, STCRight.GetTouchPosition.x) * Mathf.Rad2Deg;//sağ joystick'e göre oyuncuyu döndürür
        rb.rotation = angle;

        
        if (isDashButtonDown == true)
        {
            rb.MovePosition(rb.position + lookDirection.normalized * dashAmount);
            isDashButtonDown = false;
        }
        
    }

}
