using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressPhoneNum : MonoBehaviour
{
    public Text numTxt;
    string nums = "";
    List<string> numTxtList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        numTxt.text = "";
    }

    public void Press1()
    {
        numTxtList.Add("1");
        printNum();
    }

    public void Press2()
    {
        numTxtList.Add("2");
        printNum();
    }
    public void Press3()
    {
        numTxtList.Add("3");
        printNum();
    }
    public void Press4()
    {
        numTxtList.Add("4");
        printNum();
    }
    public void Press5()
    {
        numTxtList.Add("5");
        printNum();
    }
    public void Press6()
    {
        numTxtList.Add("6");
        printNum();
    }
    public void Press7()
    {
        numTxtList.Add("7");
        printNum();
    }
    public void Press8()
    {
        numTxtList.Add("8");
        printNum();
    }
    public void Press9()
    {
        numTxtList.Add("9");
        printNum();
    }
    public void Press0()
    {
        numTxtList.Add("0");
        printNum();
    }
    public void PressStar()
    {
        numTxtList.Add("*");
        printNum();
    }
    public void PressSharp()
    {
        numTxtList.Add("#");
        printNum();
    }

    void printNum()
    {
        for (int i = 0; i < numTxtList.Count; i++)
        {
            nums = nums + numTxtList[i];
        }
        numTxt.text = nums;
        nums = "";
    }

    public void StartCall()
    {
        if( numTxt.text == "027358994") //옳게 입력했을때
        {
            SceneManager.LoadScene("Scene_Call_2");
        }
        else
        {
            //틀리게 입력했을때
        }
    }

    public void EraseNum()
    {
        if(numTxtList.Count > 0)    //리스트에 숫자가 존재할때
        {
            numTxtList.RemoveAt(numTxtList.Count - 1);
            printNum();
        }
        else
        {

        }
        
    }
}
