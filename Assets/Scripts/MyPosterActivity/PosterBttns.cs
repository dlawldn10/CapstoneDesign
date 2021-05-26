using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PosterBttns : MonoBehaviour
{
    public GameObject Palette;
    public GameObject StickerSV;
    public GameObject PhraseSV;
    public GameObject SVposition;

    public GameObject RedGroup;
    public GameObject OrangedGroup;
    public GameObject YellowGroup;
    public GameObject GreenGroup;
    public GameObject YellogreenGroup;
    public GameObject BlueGroup;
    public GameObject SkyblueGroup;
    public GameObject PurpleGroup;
    public GameObject BrownGroup;
    public GameObject BlackGroup;
    public GameObject WhiteGroup;

    GameObject tmp;
    GameObject tmp2;

    public static string nowColor = "";
    public static int nowColorSize = 0;
    public static bool isPaintMode = false;


    private void Start()
    {
        turnOffOthers();
    }
    public void PhraseBttn()
    {
        turnOffOthers();
        tmp = Instantiate(PhraseSV, SVposition.transform.position, Quaternion.identity);
        tmp.transform.SetParent(GameObject.Find("Canvas").transform);
        

    }

    public void StickerBttn()
    {
        turnOffOthers();
        tmp2 = Instantiate(StickerSV, SVposition.transform.position, Quaternion.identity);
        tmp2.transform.SetParent(GameObject.Find("Canvas").transform);
        
    }

    public void PaintBttn()
    {
        
        if (Palette.activeSelf)
        {
            Palette.SetActive(false);
            isPaintMode = false;
        }
        else
        {
            turnOffOthers();        //다른 툴 누른 상태에서 누르는 경우 + 아무것도 안하고 닫는 경우
            Palette.SetActive(true);
            isPaintMode = true;
        }
        
        
    }

    public void BackBttn()
    {
        if(PaintInstantiate.workList.Count - 2 < 0)
        {

        }
        else
        {
            Destroy(PaintInstantiate.workList[PaintInstantiate.workList.Count - 2]);
            PaintInstantiate.workList.RemoveAt(PaintInstantiate.workList.Count - 2);
        }
        
    }



    void turnOffOthers()
    {
        isPaintMode = false;
        Palette.SetActive(false);
        Destroy(tmp2);
        Destroy(tmp);
    }


    //물감들 버튼
    void turnOffAllColors()
    {
        RedGroup.SetActive(false);
        OrangedGroup.SetActive(false);
        YellowGroup.SetActive(false);
        YellogreenGroup.SetActive(false);
        GreenGroup.SetActive(false);
        BlueGroup.SetActive(false);
        SkyblueGroup.SetActive(false);
        PurpleGroup.SetActive(false);
        BrownGroup.SetActive(false);
        BlackGroup.SetActive(false); 
        WhiteGroup.SetActive(false);
    }

    public void setColorSize_1()
    {
        nowColorSize = 1;
    }

    public void setColorSize_2()
    {
        nowColorSize = 2;
    }

    public void setColorSize_3()
    {
        nowColorSize = 3;
    }

    public void clcikRed()
    {
        turnOffAllColors();
        RedGroup.SetActive(true);
        nowColor = "RED";
    }

    public void clcikOrange()
    {
        turnOffAllColors();
        OrangedGroup.SetActive(true);
        nowColor = "ORANGE";
    }

    public void clcikYellow()
    {
        turnOffAllColors();
        YellowGroup.SetActive(true);
        nowColor = "YELLOW";
    }

    public void clcikGreen()
    {
        turnOffAllColors();
        GreenGroup.SetActive(true);
        nowColor = "GREEN";
    }

    public void clcikYellowgreen()
    {
        turnOffAllColors();
        YellogreenGroup.SetActive(true);
        nowColor = "YELLOWGREEN";
    }

    public void clcikBlue()
    {
        turnOffAllColors();
        BlueGroup.SetActive(true);
        nowColor = "BLUE";
    }

    public void clcikSkyblue()
    {
        turnOffAllColors();
        SkyblueGroup.SetActive(true);
        nowColor = "SKYBLUE";
    }

    public void clcikPurple()
    {
        turnOffAllColors();
        PurpleGroup.SetActive(true);
        nowColor = "PURPLE";
    }

    public void clcikBrown()
    {
        turnOffAllColors();
        BrownGroup.SetActive(true);
        nowColor = "BROWN";
    }

    public void clcikBlack()
    {
        turnOffAllColors();
        BlackGroup.SetActive(true);
        nowColor = "BLACK";
    }

    public void clcikWhite()
    {
        turnOffAllColors();
        WhiteGroup.SetActive(true);
        nowColor = "WHITE";
    }



}
