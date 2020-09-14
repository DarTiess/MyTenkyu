using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GameManager))]
public class Managet : MonoBehaviour
{

    public static GameManager gameManager { get;private set; }

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
}
