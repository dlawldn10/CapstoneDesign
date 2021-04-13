using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public GameObject ExitPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Application.platform == RuntimePlatform.Android)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            ExitPanel.SetActive(true);
        }
    }

    

    public void Save()
    {
        PlayerPrefs.SetInt("PageNum", SceneMgr.PageNum);
        PlayerPrefs.SetInt("EpiNum", SceneMgr.EpiNum);

        PlayerPrefs.SetInt("Epi0_ClearPageNum", SceneMgr.Epi0_ClearPageNum);
        PlayerPrefs.SetInt("Epi1_ClearPageNum", SceneMgr.Epi1_ClearPageNum);
        PlayerPrefs.SetInt("Epi2_ClearPageNum", SceneMgr.Epi2_ClearPageNum);
        PlayerPrefs.SetInt("Epi3_ClearPageNum", SceneMgr.Epi3_ClearPageNum);
        PlayerPrefs.SetInt("Epi4_ClearPageNum", SceneMgr.Epi4_ClearPageNum);
        PlayerPrefs.SetInt("OpenEpiNum", SceneMgr.OpenEpiNum);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("PageNum"))
        {
            SceneMgr.PageNum = PlayerPrefs.GetInt("PageNum");
            SceneMgr.EpiNum = PlayerPrefs.GetInt("EpiNum");
            SceneMgr.OpenEpiNum = PlayerPrefs.GetInt("OpenEpiNum");
        }

        //if (PlayerPrefs.HasKey("OpenEpiNum"))
        //{
        //    SceneMgr.OpenEpiNum = PlayerPrefs.GetInt("OpenEpiNum");
        //    SceneMgr.Epi0_ClearPageNum = PlayerPrefs.GetInt("Epi0_ClearPageNum");
        //    SceneMgr.Epi1_ClearPageNum = PlayerPrefs.GetInt("Epi1_ClearPageNum");
        //    SceneMgr.Epi2_ClearPageNum = PlayerPrefs.GetInt("Epi2_ClearPageNum");
        //    SceneMgr.Epi3_ClearPageNum = PlayerPrefs.GetInt("Epi3_ClearPageNum");
        //    SceneMgr.Epi4_ClearPageNum = PlayerPrefs.GetInt("Epi4_ClearPageNum");


        //}
    }

    public void ExitYes()
    {
        Save();
        Application.Quit();   // 앱을 종료
    }
    public void ExitNo()
    {
        Time.timeScale = 1f; // 먼저 시간을 다시 가도록 원복 
        ExitPanel.SetActive(false); // Exit 팝업창을 지운다.
    }

    //출처: https://soo0100.tistory.com/779 [Thank you for everything in the world]

}
