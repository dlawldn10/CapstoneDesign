using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour
{
    public GameObject ErrorUI;
    public Text Errortext;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickClosedEpi()
    {
        ErrorUI.SetActive(true);
        Errortext.text = "먼저 이전 편을 학습해주세요!";
        Invoke("vanish", 2);
    }

    void vanish()
    {
        ErrorUI.SetActive(false);
    }
}
