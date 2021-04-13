using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//씬의 전환을 담당
//모든 씬에 들어감
public class SceneMgr : MonoBehaviour
{
    SaveLoad saveLoad;
    //PlaySounds sound;

    public static int Epi0_ClearPageNum = 0;  //사용자의 최대 진도 페이지
    public static int Epi1_ClearPageNum = 0;  //사용자의 최대 진도 페이지
    public static int Epi2_ClearPageNum = 0;  //사용자의 최대 진도 페이지
    public static int Epi3_ClearPageNum = 0;  //사용자의 최대 진도 페이지
    public static int Epi4_ClearPageNum = 0;  //사용자의 최대 진도 페이지

    public static int OpenEpiNum = 0;   //열린 에피소드 상황.

    public static int PageNum = 0;  //사용자가 현재 있는 페이지
    public static int EpiNum = 0;   //사용자가 현재 있는 에피소드

    public static int Epi0_FinPage = 1;    //에피소드별 마지막 페이지. 수정되면 바꿔야함.
    public static int Epi1_FinPage = 9;    
    public static int Epi2_FinPage = 16;    
    public static int Epi3_FinPage = 2;    
    public static int Epi4_FinPage = 2;    

    //public bool isEpi0Clear = false;
    //public bool isEpi1Clear = false;
    //public bool isEpi2Clear = false;
    //public bool isEpi3Clear = false;
    //public bool isEpi4Clear = false;


    private void Start()
    {
        saveLoad = GameObject.Find("SceneMgr").GetComponent<SaveLoad>();
        //sound = GameObject.Find("Button_Next").GetComponent<PlaySounds>();
        //PageNum = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(EpiNum + "," + PageNum);
    }

    private void Update()
    {
        SaveClearPage();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Application.Quit();
            saveLoad.Save();
        }

    }

    //클리어한 최대 페이지(학습진도)를 기록함.
    void SaveClearPage()
    {
       if(Epi0_ClearPageNum < PageNum && EpiNum == 0)
        {
            Epi0_ClearPageNum = PageNum;
        }
       else if(Epi1_ClearPageNum < PageNum && EpiNum == 1)
        {
            Epi1_ClearPageNum = PageNum;
        }
       else if(Epi2_ClearPageNum < PageNum && EpiNum == 2)
        {
            Epi2_ClearPageNum = PageNum;
        }
       else if(Epi3_ClearPageNum < PageNum && EpiNum == 3)
        {
            Epi3_ClearPageNum = PageNum;
        }
       else if(Epi4_ClearPageNum < PageNum && EpiNum == 4)
        {
            Epi4_ClearPageNum = PageNum;
        }
        //Debug.Log("Epi0 : " + Epi0_ClearPageNum);
        //Debug.Log("Epi1 : " + Epi1_ClearPageNum);
        //Debug.Log("Epi2 : " + Epi2_ClearPageNum);

    }

    public int  FindNextPage()  //다음 페이지 찾기, 반환
    {

        if (EpiNum == 0 && ++PageNum > Epi0_FinPage)
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고
            ++EpiNum;   //에피소드 넘버가 1늘어난다.
            OpenEpiNum = 1;
            return PageNum;
        }
        else if (EpiNum == 1 && ++PageNum > Epi1_FinPage)     //현재 에피소드가 1이고 에피소드2의 마지막 페이지에 도달했을 때
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고
            ++EpiNum;   //에피소드 넘버가 1늘어난다.
            OpenEpiNum = 2;
            return PageNum;
        }
        else if (EpiNum == 2 && ++PageNum > Epi2_FinPage)     //현재 에피소드가 2이고 에피소드2의 마지막 페이지에 도달했을 때
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고
            ++EpiNum;   //에피소드 넘버가 1늘어난다.
            OpenEpiNum = 3;
            return PageNum;
        }
        else if (EpiNum == 3 && ++PageNum / Epi3_FinPage >= 1)     //현재 에피소드가 3이고 에피소드3의 마지막 페이지에 도달했을 때
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고
            ++EpiNum;   //에피소드 넘버가 1늘어난다.
            OpenEpiNum = 4;
            return PageNum;
        }
        else if (EpiNum == 4 && ++PageNum / Epi4_FinPage >= 1)     //현재 에피소드가 4이고 에피소드4의 마지막 페이지에 도달했을 때
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고..
        }
        
        return PageNum;
    }

    public int FindBackPage()   //이전 페이지 찾기, 반환
    {
        if (EpiNum == 1 && PageNum == 0)
        {
            --EpiNum;
            PageNum = Epi0_FinPage;
        }
        else if (EpiNum == 2 && PageNum == 0)
        {
            --EpiNum;
            PageNum = Epi1_FinPage;
        }
        else if (EpiNum == 3 && PageNum == 0)
        {
            --EpiNum;
            PageNum = Epi2_FinPage;
        }
        else if (EpiNum == 4 && PageNum == 0)
        {
            --EpiNum;
            PageNum = Epi3_FinPage;
        }
        else
        {
            PageNum -= 1;
        }
        return PageNum;
    }

    public int getEpiNum()
    {
        return EpiNum;
    }

    public void ClearStart()
    {
        SceneMgr.PageNum = 0;
        SceneMgr.EpiNum = 0;
        gotoNextPage();
    }

    //버튼에 적용될 함수
    public void gotoNextPage()
    {
        //sound.SceneChangeSound();
        int nextPage = FindNextPage();      //밑줄에 바로넣으면 EpiNum 연산이랑 순서 꼬여서 연산오류 발생. 변수 만들어서 먼저계산.
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + nextPage.ToString());
        //Debug.Log(EpiNum + "," + PageNum);
    }
    public void gotoBackPage()
    {
        //sound.SceneChangeSound();
        int backPage = FindBackPage();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + backPage.ToString());
    }

    public void gotoHome()
    {
        SceneManager.LoadScene("Scene0_0");
        PageNum = 0;
        EpiNum = 0;
    }

    public void gotoScene1_1()  //에피소드1의 1단원으로 가기.
    {

        EpiNum = 1;
        PageNum = 1;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }
    public void gotoScene1_3()  //에피소드1의 1단원으로 가기.
    {

        EpiNum = 1;
        PageNum = 3;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }
    
    public void gotoScene1_6()  //에피소드1의 2단원으로 가기.
    {

        EpiNum = 1;
        PageNum = 6;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene1_9()  //에피소드1의 3단원으로 가기.
    {

        EpiNum = 1;
        PageNum = 9;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    //

    public void gotoScene2_2()  //에피소드1의 1단원으로 가기.
    {

        EpiNum = 2;
        PageNum = 2;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_3()  //에피소드1의 1단원으로 가기.
    {

        EpiNum = 2;
        PageNum = 3;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_5()  //에피소드1의 2단원으로 가기.
    {

        EpiNum = 2;
        PageNum = 5;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_15()  //에피소드1의 3단원으로 가기.
    {

        EpiNum = 2;
        PageNum = 15;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_14()  //에피소드1의 3단원으로 가기.
    {

        EpiNum = 2;
        PageNum = 14;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_13()  //에피소드1의 3단원으로 가기.
    {

        EpiNum = 2;
        PageNum = 13;
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_Call_1()  
    {
        SceneManager.LoadScene("Scene_Call_1");
    }

    public void gotoScene2_Call_2()
    {
        SceneManager.LoadScene("Scene_Call_2");
    }

    public void gotoScene2_Call_3()  
    {
        SceneManager.LoadScene("Scene_Call_3");
    }

    public void gotoScene2_Call_4()
    {
        SceneManager.LoadScene("Scene_Call_4");
    }

    public void gotoScene2_Call_5()
    {
        SceneManager.LoadScene("Scene_Call_5");
    }

    public void gotoScene2_Call_6()
    {
        SceneManager.LoadScene("Scene_Call_6");
    }

    public void gotoScene2_Call_7()
    {
        SceneManager.LoadScene("Scene_Call_7");
    }

    public void gotoScene_StoryTelling_1()
    {
        SceneManager.LoadScene("Scene_StoryTelling_1");
    }
    public void gotoScene_StoryTelling_2()
    {
        SceneManager.LoadScene("Scene_StoryTelling_2");
    }
    public void gotoScene_StoryTelling_3()
    {
        SceneManager.LoadScene("Scene_StoryTelling_3");
    }
    public void gotoScene_StoryTelling_4()
    {
        SceneManager.LoadScene("Scene_StoryTelling_4");
    }
    public void gotoScene_StoryTelling_5()
    {
        SceneManager.LoadScene("Scene_StoryTelling_5");
    }
    public void gotoScene_StoryTelling_6()
    {
        SceneManager.LoadScene("Scene_StoryTelling_6");
    }
    public void gotoScene_StoryTelling_7()
    {
        SceneManager.LoadScene("Scene_StoryTelling_7");
    }

    public void gotoScene_StoryTelling_8()
    {
        SceneManager.LoadScene("Scene_StoryTelling_8");
    }
    public void gotoScene_StoryTelling_9()
    {
        SceneManager.LoadScene("Scene_StoryTelling_9");
    }

    public void backToActivity()
    {
        SceneManager.LoadScene("Scene2_12");
    }


    public void ExitProgram()
    {
        //Application.Quit();   //스마트폰에서 할때는 주석풀기
        //saveLoad.Save();    //저장
        AppHelper.Quit();   //스마트폰에서 할때는 주석처리하기
       
    }

    public void LoadScene()
    {
        saveLoad.Load();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public static class AppHelper   //에디터에서 application.quit해주는 함수. 빌드하고 핸드폰에서 할때는 주석처리하기.
    {
#if UNITY_WEBPLAYER
     public static string webplayerQuitURL = "http://google.com";
#endif
        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
        }
    }
}
