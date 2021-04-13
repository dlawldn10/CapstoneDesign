using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEpiOpened : MonoBehaviour
{
    //SceneMgr opened;

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
        //opened = GameObject.Find("SceneMgr").GetComponent<SceneMgr>();
        OpenEpi();
    }

    void OpenEpi()
    {
        if(SceneMgr.OpenEpiNum > 1)
        {
            Epi2_closed.SetActive(false);
            Epi2_opend.SetActive(true);
        }
        else if (SceneMgr.OpenEpiNum > 2)
        {
            Epi3_closed.SetActive(false);
            Epi3_opend.SetActive(true);
        }
        else if (SceneMgr.OpenEpiNum > 3)
        {
            Epi4_closed.SetActive(false);
            Epi4_opend.SetActive(true);
        }

    }

    
}
