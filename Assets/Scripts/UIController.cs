using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class UIController : MonoBehaviour
{
    public GameObject shere;
    float smooth = 2.0F;
    float tiltAngle = 30.0F;
    Quaternion target;
    float tiltAroundZ;
        float tiltAroundX;
    public float speed = 0.1F;
    // Start is called before the first frame update
    void Start()
    {
        tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
      
    }
        // Update is called once per frame
        void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
            target = Quaternion.Euler(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
            shere.gameObject.transform.rotation = Quaternion.Slerp(shere.gameObject.transform.rotation, target, Time.deltaTime * smooth);
        }
    }
    public void OnLeftClick()
    {
        target = Quaternion.Euler(tiltAroundX,0, tiltAroundZ+30f);
        shere.gameObject.transform.rotation = Quaternion.Slerp(shere.gameObject.transform.rotation, target, Time.deltaTime * smooth);
    }
        public void OnRightClick()
    {
        target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ - 30f);
        shere.gameObject.transform.rotation = Quaternion.Slerp(shere.gameObject.transform.rotation, target, Time.deltaTime * smooth);

    }
}
