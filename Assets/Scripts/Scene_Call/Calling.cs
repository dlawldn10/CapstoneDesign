using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Calling : MonoBehaviour
{
    
    public void StartCalling()
    {
        //Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Scene_Call_1");
    }

    //public void backToActivity()
    //{
    //    SceneManager.LoadScene("Scene2_13");
    //    //Screen.orientation = ScreenOrientation.LandscapeLeft;
    //}
}
