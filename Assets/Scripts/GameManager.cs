using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int curLevel { get; private set; }
    public int maxLevel { get; private set; }

    public void Startup()
    {
        Debug.Log("Mission manager started...");

        UpdateData(1, 3);
        
    }


    public void UpdateData(int curLevel, int maxLevel)
    {
        this.curLevel = curLevel;
        this.maxLevel = maxLevel;
    }
    public void GoToNext()
    {
        if (curLevel < maxLevel)
        {
             curLevel++;
            string name = "Scene_" + curLevel;
           
            Debug.Log("Loading" + name);
            SceneManager.LoadScene(name);

        }
        else 
        {
            curLevel=2;
            string name = "Scene_" + curLevel;
            SceneManager.LoadScene(name);
            Debug.Log("Last level");
           
        }
    }
    public void RestartCurrent()
    {
        curLevel = 1;
        string name = "Scene_" + curLevel;
        Debug.Log("Loading " + name);
        SceneManager.LoadScene(name);

    }

}
