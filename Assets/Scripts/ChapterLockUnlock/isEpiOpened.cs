using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEpiOpened : MonoBehaviour
{

    public GameObject Epi1_opend;
    public GameObject Epi2_opend;
    public GameObject Epi2_closed;
    public GameObject Epi3_opend;
    public GameObject Epi3_closed;
    public GameObject Epi4_opend;
    public GameObject Epi4_closed;


    // Start is called before the first frame update
    void Start()
    {
        OpenEpi();
    }

    private void Update()
    {
        
    }

    //1은 원래 열려있음
    void OpenEpi()
    {
        if(SceneMgr.ClearEpiNum <= 1)   //에피소드 1까지만 플레이한 경우
        {
            //모두 닫기
            Epi2_closed.SetActive(true);
            Epi2_opend.SetActive(false);
            Epi3_closed.SetActive(true);
            Epi3_opend.SetActive(false);
            Epi4_closed.SetActive(true);
            Epi4_opend.SetActive(false);
        }
        else if (SceneMgr.ClearEpiNum == 2) //에피소드 2까지만 플레이한 경우
        {
            //1, 2 열기
            Epi2_closed.SetActive(false);
            Epi2_opend.SetActive(true);

            Epi3_closed.SetActive(true);
            Epi3_opend.SetActive(false);
            Epi4_closed.SetActive(true);
            Epi4_opend.SetActive(false);
        }
        else if (SceneMgr.ClearEpiNum == 3) //에피소드 3까지만 플레이한 경우
        {
            //1, 2, 3 열기
            Epi2_closed.SetActive(false);
            Epi2_opend.SetActive(true);
            Epi3_closed.SetActive(false);
            Epi3_opend.SetActive(true);

            Epi4_closed.SetActive(true);
            Epi4_opend.SetActive(false);
        }
        else if (SceneMgr.ClearEpiNum == 4) //에피소드 모두 플레이한 경우
        {
            //1, 2, 3, 4 열기
            Epi2_closed.SetActive(false);
            Epi2_opend.SetActive(true);
            Epi3_closed.SetActive(false);
            Epi3_opend.SetActive(true);
            Epi4_closed.SetActive(false);
            Epi4_opend.SetActive(true);
        }

    }

    
}
