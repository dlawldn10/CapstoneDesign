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
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffOthers();
        tmp = Instantiate(PhraseSV, SVposition.transform.position, Quaternion.identity);
        tmp.transform.SetParent(GameObject.Find("Canvas").transform);
        

    }

    public void StickerBttn()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffOthers();
        tmp2 = Instantiate(StickerSV, SVposition.transform.position, Quaternion.identity);
        tmp2.transform.SetParent(GameObject.Find("Canvas").transform);
        
    }

    public void PaintBttn()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
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
            GameObject soundPlayer = GameObject.Find("SoundPlayer");
            soundPlayer.SendMessage("plainBttnClick");
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
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        nowColorSize = 1;
    }

    public void setColorSize_2()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        nowColorSize = 2;
    }

    public void setColorSize_3()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        nowColorSize = 3;
    }

    public void clcikRed()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        RedGroup.SetActive(true);
        nowColor = "RED";
    }

    public void clcikOrange()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        OrangedGroup.SetActive(true);
        nowColor = "ORANGE";
    }

    public void clcikYellow()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        YellowGroup.SetActive(true);
        nowColor = "YELLOW";
    }

    public void clcikGreen()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        GreenGroup.SetActive(true);
        nowColor = "GREEN";
    }

    public void clcikYellowgreen()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        YellogreenGroup.SetActive(true);
        nowColor = "YELLOWGREEN";
    }

    public void clcikBlue()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        BlueGroup.SetActive(true);
        nowColor = "BLUE";
    }

    public void clcikSkyblue()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        SkyblueGroup.SetActive(true);
        nowColor = "SKYBLUE";
    }

    public void clcikPurple()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        PurpleGroup.SetActive(true);
        nowColor = "PURPLE";
    }

    public void clcikBrown()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        BrownGroup.SetActive(true);
        nowColor = "BROWN";
    }

    public void clcikBlack()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        BlackGroup.SetActive(true);
        nowColor = "BLACK";
    }

    public void clcikWhite()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        turnOffAllColors();
        WhiteGroup.SetActive(true);
        nowColor = "WHITE";
    }



}
