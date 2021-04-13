using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VoiceController))]
public class VoiceTest : MonoBehaviour
{

    public Text nowSpeaking;
    public Text guidText;
    public Text hint;
    public GameObject next;
    string answer = "";
    //int i = 0;

    VoiceController voiceController;

    public void GetSpeech()
    {
        voiceController.GetSpeech();
    }

    void Start()
    {
        next.SetActive(false);
        voiceController = GetComponent<VoiceController>();
        answer = guidText.text.Substring(1, guidText.text.Length - 2);

    }

    void OnEnable()
    {
        VoiceController.resultRecieved += OnVoiceResult;
    }

    void OnDisable()
    {
        VoiceController.resultRecieved -= OnVoiceResult;
    }

    void OnVoiceResult(string text)
    {
        nowSpeaking.text = text;     //사용자가 말한 텍스트
        hint.gameObject.SetActive(false);
        //setGuidTxt1(text);     //정답
        isAnswer(text);

    }

    void isAnswer(string text)
    {
        if(answer == text){   //답이 같을때
            next.SetActive(true);
        }
    }

    //void setGuidTxt1(string text)
    //{
    //    if (text == GuidTxt_1[i])   //바르게 말했을때
    //    {
    //        if (i == GuidTxt_1.Count - 1)
    //        {
    //            //setGuidTxt2(text);
    //            audioScource.PlayOneShot(clips[1]);
    //        }
    //        else
    //        {
    //            i++;
    //            StartCoroutine(WaitForIt(GuidTxt_1[i]));    //1초동안 바르게 말한거 보여주고
    //        }
            
    //    }
    //}

    //void setGuidTxt2(string text)
    //{
    //    if (text == GuidTxt_2[i])
    //    {
    //        if (i == GuidTxt_2.Count)
    //        {
    //            setGuidTxt3(text);
    //        }
    //        i++;
    //        guidText.text = GuidTxt_2[i];
    //    }
    //}

    //void setGuidTxt3(string text)
    //{
    //    if (text == GuidTxt_3[i])
    //    {
    //        if (i == GuidTxt_3.Count)
    //        {

    //        }
    //        else
    //        {
    //            i++;
    //            guidText.text = GuidTxt_3[i];
    //        }

    //    }
    //}

    //IEnumerator WaitForIt(string txt)
    //{
    //    yield return new WaitForSeconds(1.7f);
    //    guidText.text = txt;
    //    nowSpeaking.text = "";
    //}
}
