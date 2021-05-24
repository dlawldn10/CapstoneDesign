using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterBttns : MonoBehaviour
{
    public GameObject Palette;
    public GameObject StickerSV;
    public GameObject PhraseSV;

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
        PhraseSV.SetActive(true);
    }

    public void StickerBttn()
    {
        turnOffOthers();
        StickerSV.SetActive(true);
    }

    public void PaintBttn()
    {
        turnOffOthers();
        isPaintMode = true;
        Palette.SetActive(true);
    }

    public void BackBttn()
    {

    }

    void turnOffOthers()
    {
        isPaintMode = false;
        Palette.SetActive(false);
        StickerSV.SetActive(false);
        PhraseSV.SetActive(false);
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
