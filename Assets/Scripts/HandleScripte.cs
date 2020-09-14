using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScripte : MonoBehaviour
{
    float tiltAroundZ;
    float tiltAroundX;
    // Start is called before the first frame update
    void Start()
    {
        tiltAroundZ = Input.GetAxis("Horizontal") * 30f;
        tiltAroundX = Input.GetAxis("Vertical") * 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
            Debug.Log("Touch!!!");
    }
    void OnMouseDown()
    {
       Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ + 30f);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2f);
    }
}
