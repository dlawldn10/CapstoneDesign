using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChat : MonoBehaviour
{
    public GameObject Phone;
    public GameObject next;
    int chatNum = 0;

    void Start()
    {
        next.SetActive(false);
        InvokeRepeating("PhoneChat", 1, 2);
    }

    
    public void PhoneChat()
    {
        Phone.transform.GetChild(chatNum).gameObject.SetActive(true);   //다음 채팅 표시
        chatNum++;
        if (chatNum == Phone.transform.childCount)  //표시해야 하는 채팅을 모두 표시하면
        {
            chatNum = 0;
            CancelInvoke();     
            next.SetActive(true);   //다음 페이지로 가는 버튼 활성화
        }
    }


}

