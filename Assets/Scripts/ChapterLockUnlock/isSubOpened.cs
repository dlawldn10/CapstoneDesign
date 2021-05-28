using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSubOpened : MonoBehaviour
{
    public GameObject Sub1_opend;
    public GameObject Sub2_opend;
    public GameObject Sub2_closed;
    public GameObject Sub3_opend;
    public GameObject Sub3_closed;
    public GameObject Sub4_opend;
    public GameObject Sub4_closed;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneMgr.EpiNum == 1)
        {
            Epi1_OpenSub();
        }
        else if (SceneMgr.EpiNum == 2)
        {
            Epi2_OpenSub();
        }
        else if (SceneMgr.EpiNum == 3)
        {
            Epi3_OpenSub();
        }
        else if (SceneMgr.EpiNum == 4)
        {
            Epi4_OpenSub();
        }
    }

    void Epi1_OpenSub()
    {
        
        if (SceneMgr.ClearPageNum < SceneMgr.Epi1_Sub2)   //처음단원만 
        {
            //모두 닫기
            Sub2_closed.SetActive(true);
            Sub2_opend.SetActive(false);
            Sub3_closed.SetActive(true);
            Sub3_opend.SetActive(false);
            Debug.Log("옳지않은 실행");
            Debug.Log(SceneMgr.ClearPageNum);
        }
        else if (SceneMgr.Epi1_Sub2 <= SceneMgr.ClearPageNum && SceneMgr.ClearPageNum < SceneMgr.Epi1_Sub3) 
        {
            Debug.Log("옳은 실행");
            //1, 2 열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);

            Sub3_closed.SetActive(true);
            Sub3_opend.SetActive(false);
        }
        else if (SceneMgr.Epi1_Sub3 <= SceneMgr.ClearPageNum)//3단원 까지 플레이한 경우 5,6,7,8,9
        {
            //1, 2, 3 열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);
            Sub3_closed.SetActive(false);
            Sub3_opend.SetActive(true);

        }

    }

    void Epi2_OpenSub()
    {

        if (SceneMgr.ClearPageNum < SceneMgr.Epi2_Sub2)   //1단원 까지 플레이한 경우
        {
            //모두 닫기
            Sub2_closed.SetActive(true);
            Sub2_opend.SetActive(false);
            Sub3_closed.SetActive(true);
            Sub3_opend.SetActive(false);
        }
        else if (SceneMgr.Epi2_Sub2 <= SceneMgr.ClearPageNum && SceneMgr.ClearPageNum < SceneMgr.Epi2_Sub3) //2단원 까지 플레이한 경우
        {
            //1, 2 열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);

            Sub3_closed.SetActive(true);
            Sub3_opend.SetActive(false);
        }
        else if (SceneMgr.Epi2_Sub3 <= SceneMgr.ClearPageNum) //3단원 까지 플레이한 경우
        {
            //1, 2, 3 열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);
            Sub3_closed.SetActive(false);
            Sub3_opend.SetActive(true);

        }

    }

    void Epi3_OpenSub()
    {


        if (SceneMgr.ClearPageNum < SceneMgr.Epi3_Sub2)   //1단원 까지 플레이한 경우
        {
            //모두 닫기
            Sub2_closed.SetActive(true);
            Sub2_opend.SetActive(false);
            Sub3_closed.SetActive(true);
            Sub3_opend.SetActive(false);
        }
        else if (SceneMgr.Epi3_Sub2 <= SceneMgr.ClearPageNum && SceneMgr.ClearPageNum < SceneMgr.Epi3_Sub3) //2단원 까지 플레이한 경우
        {
            //1, 2 열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);

            Sub3_closed.SetActive(true);
            Sub3_opend.SetActive(false);
        }
        else if (SceneMgr.Epi3_Sub3 <= SceneMgr.ClearPageNum) //3단원 까지 플레이한 경우
        {
            //1, 2, 3 열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);
            Sub3_closed.SetActive(false);
            Sub3_opend.SetActive(true);

        }

    }

    void Epi4_OpenSub()
    {


        if (SceneMgr.ClearPageNum < SceneMgr.Epi4_Sub2)   //1단원 까지 플레이한 경우
        {
            //모두 닫기
            Sub2_closed.SetActive(true);
            Sub2_opend.SetActive(false);
            Sub3_closed.SetActive(true);
            Sub3_opend.SetActive(false);
            Sub4_closed.SetActive(true);
            Sub4_opend.SetActive(false);
        }
        else if (SceneMgr.Epi4_Sub2 <= SceneMgr.ClearPageNum && SceneMgr.ClearPageNum < SceneMgr.Epi4_Sub3) //2단원 까지 플레이한 경우
        {
            //1, 2 열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);

            Sub3_closed.SetActive(true);
            Sub3_opend.SetActive(false);
            Sub4_closed.SetActive(true);
            Sub4_opend.SetActive(false);
        }
        else if (SceneMgr.Epi4_Sub3 <= SceneMgr.ClearPageNum && SceneMgr.ClearPageNum < SceneMgr.Epi4_Sub4) //3단원 까지 플레이한 경우
        {
            //1, 2, 3 열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);
            Sub3_closed.SetActive(false);
            Sub3_opend.SetActive(true);

            Sub4_closed.SetActive(true);
            Sub4_opend.SetActive(false);

        }
        else if (SceneMgr.Epi4_Sub4 <= SceneMgr.ClearPageNum) //4단원 까지 플레이한 경우
        {
            //모두열기
            Sub2_closed.SetActive(false);
            Sub2_opend.SetActive(true);
            Sub3_closed.SetActive(false);
            Sub3_opend.SetActive(true);
            Sub4_closed.SetActive(false);
            Sub4_opend.SetActive(true);
        }

    }

    

}
