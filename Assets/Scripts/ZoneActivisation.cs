using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneActivisation : MonoBehaviour
{
    public GameObject sphere;
    public GameObject ramp2;
    public GameObject ramp1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            ramp2.transform.rotation = Quaternion.identity;
            ramp2.SetActive(true);
            ramp1.SetActive(false);
        }
    }
}
