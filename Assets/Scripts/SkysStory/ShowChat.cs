using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowChat : MonoBehaviour
{
    public GameObject Phone;
    public GameObject next;
    int chatNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        next.SetActive(false);
        InvokeRepeating("PhoneChat", 1, 2);
    }

    // Update is called once per frame
    
    public void PhoneChat()
    {
        Phone.transform.GetChild(chatNum).gameObject.SetActive(true);
        chatNum++;
        if (chatNum == Phone.transform.childCount)
        {
            chatNum = 0;
            CancelInvoke();
            next.SetActive(true);
        }
    }


}

