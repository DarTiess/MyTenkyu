using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneActivisation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        //SceneManager.LoadScene("Scene_2");
        Managet.gameManager.GoToNext(); 
    }
}
