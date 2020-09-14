using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchField : MonoBehaviour
{
    private Touch touch;
    private Vector2 oldTouchPosition;
    private Vector2 NewTouchPosition;

    float tiltAroundZ;
   float tiltAroundX;

    private void Start()
    {
        tiltAroundZ = Input.GetAxis("Horizontal") * 20f;
        tiltAroundX = Input.GetAxis("Vertical") *30f;
      
    }
    private void Update()
    {
        RotateThings();
    }
    private void OnMouseDown()
    {
        
    }
    private void RotateThings()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                oldTouchPosition = touch.position;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                NewTouchPosition = touch.position;
            }

            Vector2 rotDirection = oldTouchPosition - NewTouchPosition;
          
            if (rotDirection.x < 0)
            {
                RotateRight();
                if (rotDirection.y > 0)
                {
                    RotateUp();
                }
                else if (rotDirection.y < 0)
                {
                    RotateDown();
                }
            }

            else if (rotDirection.x > 0)
            {
                RotateLeft();
            }
           
           
        }
    }

    void RotateLeft()
    {
       
          Quaternion target= Quaternion.Euler(tiltAroundX,30f, tiltAroundZ + 15f) * transform.rotation;
         transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime *2f);

    }

    void RotateRight()
    {
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ - 15f) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2f);
    }

    void RotateUp()
    {
        Quaternion target = Quaternion.Euler(tiltAroundX, 30f, tiltAroundZ ) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2f);
    }
    void RotateDown()
    {
        Quaternion target = Quaternion.Euler(tiltAroundX, -15f, tiltAroundZ) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2f);
    }

}

   