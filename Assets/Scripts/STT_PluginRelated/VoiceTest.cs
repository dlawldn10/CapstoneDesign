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
        nowSpeaking.text = text;     //사용자가 말한 내용을 화면에 띄움
        hint.gameObject.SetActive(false);   //힌트 메세지는 사라지게함.
        isAnswer(text);     //정답인지 아닌지 판별.

    }

    void isAnswer(string text)
    {
        if(answer == text){   //답이 같을때
            next.SetActive(true);
        }
    }

    
}
