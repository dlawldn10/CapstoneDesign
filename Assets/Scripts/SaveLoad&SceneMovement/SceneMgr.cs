using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//씬의 전환을 담당
//모든 씬에 들어감
public class SceneMgr : MonoBehaviour
{
   
    SaveLoad saveLoad;
    public GameObject menu;

    public static int ClearEpiNum = 0;   //열린 에피소드 상황.
    public static int ClearPageNum = 0;  //사용자의 최대 진도 페이지 

    public static int PageNum = 0;  //사용자가 현재 있는 페이지
    public static int EpiNum = 0;   //사용자가 현재 있는 에피소드


    public static int Epi1_Sub1 = 0;  //에피소드1의 1단원 페이지
    public static int Epi1_Sub2 = 5;  //에피소드1의 2단원 페이지
    public static int Epi1_Sub3 = 8;  //에피소드1의 3단원 페이지

    public static int Epi2_Sub1 = 1;  //에피소드2의 1단원 페이지
    public static int Epi2_Sub2 = 4;  //에피소드2의 2단원 페이지
    public static int Epi2_Sub3 = 14;  //에피소드2의 3단원 페이지

    public static int Epi3_Sub1 = 1;  //에피소드3의 1단원 페이지
    public static int Epi3_Sub2 = 14;  //에피소드3의 2단원 페이지
    public static int Epi3_Sub3 = 18;  //에피소드3의 3단원 페이지

    public static int Epi4_Sub1 = 1;  //에피소드4의 1단원 페이지
    public static int Epi4_Sub2 = 5;  //에피소드4의 2단원 페이지
    public static int Epi4_Sub3 = 20;  //에피소드4의 3단원 페이지
    public static int Epi4_Sub4 = 36;  //에피소드4의 4단원 페이지

    public static int Epi0_FinPage = 1;    //에피소드별 마지막 페이지. 수정되면 바꿔야함.
    public static int Epi1_FinPage = 9;
    public static int Epi2_FinPage = 16;
    public static int Epi3_FinPage = 20;
    public static int Epi4_FinPage = 39;


    

    private void Start()
    {
        saveLoad = GameObject.Find("SceneMgr").GetComponent<SaveLoad>();
        Debug.Log(EpiNum + "_" + PageNum);
    }

    

    public void Menuclick()
    {
        if (GameObject.Find("Menu1(Clone)") != null)   //이 오브젝트가 존재하면
        {
            Destroy(GameObject.Find("Menu1(Clone)"));   //삭제
        }
        else    //존재하지 않으면
        {
            GameObject tmp = Instantiate(menu);     //생성
            

        }
    }

    public void renewProgress()
    {
        if (PageNum >= ClearPageNum)     //현재 페이지가 기록된 최대 진도보다 크면
        {
            if (0 != PageNum)
            {
                ClearPageNum = PageNum;     //최대 진도 갱신
            }
            
        }

        if (EpiNum >= ClearEpiNum)     //현재 에피소드가 기록된 최대 진도보다 크면
        {
            ClearEpiNum = EpiNum;     //최대 진도 갱신
        }


    }

    

    public int  FindNextPage()  //다음 페이지 찾기, 반환
    {

        if (EpiNum == 0 && ++PageNum > Epi0_FinPage)
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고
            ++EpiNum;   //에피소드 넘버가 1늘어난다.
            ClearPageNum = 0;
            ClearEpiNum = 1;
            return PageNum;
        }
        else if (EpiNum == 1 && ++PageNum > Epi1_FinPage)     //현재 에피소드가 1이고 에피소드2의 마지막 페이지에 도달했을 때
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고
            ++EpiNum;   //에피소드 넘버가 1늘어난다.
            ClearPageNum = 0;
            ClearEpiNum = 2;
            return PageNum;
        }
        else if (EpiNum == 2 && ++PageNum > Epi2_FinPage)     //현재 에피소드가 2이고 에피소드2의 마지막 페이지에 도달했을 때
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고
            ++EpiNum;   //에피소드 넘버가 1늘어난다.
            ClearPageNum = 0;
            ClearEpiNum = 3;
            return PageNum;
        }
        else if (EpiNum == 3 && ++PageNum > Epi3_FinPage )     //현재 에피소드가 3이고 에피소드3의 마지막 페이지에 도달했을 때
        {
            PageNum = 0;    //페이지 넘버를 0으로 되돌리고
            ++EpiNum;   //에피소드 넘버가 1늘어난다.
            ClearPageNum = 0;
            ClearEpiNum = 4;
            return PageNum;
        }
        else if (EpiNum == 4 && ++PageNum > Epi4_FinPage )     //현재 에피소드가 4이고 에피소드4의 마지막 페이지에 도달했을 때
        {
            //PageNum = 0;    //페이지 넘버를 0으로 되돌리고..
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
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        int nextPage = FindNextPage();      //밑줄에 바로넣으면 EpiNum 연산이랑 순서 꼬여서 연산오류 발생. 변수 만들어서 먼저계산.
        renewProgress();
        Debug.Log("ClearPAgeNum: "+SceneMgr.ClearPageNum);
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + nextPage.ToString());
    }
    public void gotoBackPage()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        int backPage = FindBackPage();
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + backPage.ToString());
    }

    public void gotoHome()
    {
        renewProgress();
        SceneManager.LoadScene("Scene0_0");
        PageNum = 0;
        EpiNum = 0;
    }

    public void gotoScene0_1()  //에피소드1의 1단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("startBttnClick");
        EpiNum = 0;
        PageNum = 1;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    //에피소드 선택 했을때
    public void gotoScene1_0()  //에피소드1의 1단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 1;
        PageNum = 0;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene1_1()  //에피소드1의 1단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 1;
        PageNum = 1;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene1_3()  //감정카드 고르기 활동 초기화
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 1;
        PageNum = 3;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }


    public void gotoScene1_6()  //에피소드1의 2단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 1;
        PageNum = 6;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene1_9()  //에피소드1의 3단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 1;
        PageNum = 9; 
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    //에피소드선택 했을때
    public void gotoScene2_1()  //에피소드2의 1단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 2;
        PageNum = 1;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_2()  //에피소드2의 1단원 활동으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 2;
        PageNum = 2;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    //하늘이 이야기에서 돌아올때 필요
    public void gotoScene2_3()  //에피소드1의 2단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 2;
        PageNum = 3;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_5()  //에피소드2의 2단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 2;
        PageNum = 5;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene2_15()  //에피소드2의 3단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 2;
        PageNum = 15;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

   

    public void gotoScene2_Call_1()  
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_Call_1");
    }

    public void gotoScene2_Call_2()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_Call_2");
    }

    public void gotoScene2_Call_3()  
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_Call_3");
    }

    public void gotoScene2_Call_4()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_Call_4");
    }

    public void gotoScene2_Call_5()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_Call_5");
    }

    public void gotoScene2_Call_6()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_Call_6");
    }

    public void gotoScene2_Call_7()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_Call_7");
    }

    public void gotoScene_StoryTelling_1()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_1");
    }
    public void gotoScene_StoryTelling_2()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_2");
    }
    public void gotoScene_StoryTelling_3()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_3");
    }
    public void gotoScene_StoryTelling_4()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_4");
    }
    public void gotoScene_StoryTelling_5()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_5");
    }
    public void gotoScene_StoryTelling_6()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_6");
    }
    public void gotoScene_StoryTelling_7()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_7");
    }

    public void gotoScene_StoryTelling_8()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_8");
    }
    public void gotoScene_StoryTelling_9()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene_StoryTelling_9");
    }

    public void backToActivity()    //신고하기 활동에서 다시 학습활동으로 돌아오기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 2;
        PageNum = 11;
        renewProgress();
        SceneManager.LoadScene("Scene2_11");

    }

    //에피소드 선택 버튼 눌렀을때
    public void gotoScene3_1()  //에피소드3의 1단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 3;
        PageNum = 1;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene3_2()  //에피소드3의 1단원 활동으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 3;
        PageNum = 2;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene3_15()  //에피소드3의 2단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 3;
        PageNum = 15;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene3_19()  //에피소드3의 3단원으로 가기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 3;
        PageNum = 19;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene_doMosaic()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene3_PicMosaic_doMosaic");
    }
    public void gotoScene_mosaic_O()    //답이 맞았을때 화면으로
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene3_Mosaic_O");
    }

    public void gotoScene_mosaic_X()    //답이 틀렸을때 화면으로
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SceneManager.LoadScene("Scene3_Mosaic_X");
    }

    

    public void gotoScene3_17()     //사진 올릴지 말지 선택 화면으로
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 3;
        PageNum = 17;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene3_18()  //선택지 활동 끝나고 다음 화면으로
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 3;
        PageNum = 18;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    //에피소드 선택 버튼 눌렀을때
    public void gotoScene4_1()  //에피소드4의 1단원으로 이동하기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 4;
        PageNum = 1;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }


    public void gotoScene4_2()  //에피소드4의 1단원 활동으로 이동하기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 4;
        PageNum = 2;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene4_6()  //에피소드4의 2단원으로 이동하기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 4;
        PageNum = 6;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene4_21()  //에피소드4의 3단원으로 이동하기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 4;
        PageNum = 21;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    //임시
    public void gotoScene4_36()  //에피소드4의 4단원으로 이동하기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 4;
        PageNum = 36;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void gotoScene4_37()  //에피소드4의 4단원으로 이동하기.
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        EpiNum = 4;
        PageNum = 37;
        renewProgress();
        SceneManager.LoadScene("Scene" + EpiNum.ToString() + "_" + PageNum.ToString());
    }

    public void ExitProgram()
    {
        //Application.Quit();   //스마트폰에서 할때는 주석풀기
        //saveLoad.Save();    //저장
        AppHelper.Quit();   //스마트폰에서 할때는 주석처리하기
       
    }

    public void LoadScene()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("startBttnClick");
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
