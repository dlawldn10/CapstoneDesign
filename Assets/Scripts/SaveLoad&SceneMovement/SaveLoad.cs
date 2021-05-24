using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public GameObject ExitPanel;
    GameObject prefab;

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
            prefab = Instantiate(ExitPanel, GameObject.Find("Canvas").transform); // 부모 지정
            //ExitPanel.SetActive(true);
        }
    }

    

    public void Save()
    {


        PlayerPrefs.SetInt("ClearPageNum", SceneMgr.ClearPageNum);    //최대 진도 페이지
        PlayerPrefs.SetInt("ClearEpiNum", SceneMgr.ClearEpiNum);   //최대 진도 에피소드

        PlayerPrefs.SetInt("PageNum", SceneMgr.PageNum);    //가장 최근에 머무르던 페이지
        PlayerPrefs.SetInt("EpiNum", SceneMgr.EpiNum);      //가장 최근에 머무르던 에피소드

        //PlayerPrefs.SetInt("Epi0_ClearPageNum", SceneMgr.Epi0_ClearPageNum);
        //PlayerPrefs.SetInt("Epi1_ClearPageNum", SceneMgr.Epi1_ClearPageNum);
        //PlayerPrefs.SetInt("Epi2_ClearPageNum", SceneMgr.Epi2_ClearPageNum);
        //PlayerPrefs.SetInt("Epi3_ClearPageNum", SceneMgr.Epi3_ClearPageNum);
        //PlayerPrefs.SetInt("Epi4_ClearPageNum", SceneMgr.Epi4_ClearPageNum);

    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("PageNum"))
        {
            SceneMgr.PageNum = PlayerPrefs.GetInt("PageNum");
            SceneMgr.EpiNum = PlayerPrefs.GetInt("EpiNum");
            SceneMgr.ClearEpiNum = PlayerPrefs.GetInt("ClearEpiNum");
            SceneMgr.ClearPageNum = PlayerPrefs.GetInt("ClearPageNum");
        }

        
    }

    public void ExitYes()
    {
        Save();
        Application.Quit();   // 앱을 종료
    }
    


}
