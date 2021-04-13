using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCards : MonoBehaviour
{

    public GameObject Blank1;
    public GameObject Blank2;
    public GameObject Blank3;
   
    Vector2 size = new Vector2(500, 600);
    public static List<GameObject> SelectedBttnList = new List<GameObject>();

    

    // Start is called before the first frame update
    void Start()
    {
        Blank1 = GameObject.Find("Blank1");
        Blank2 = GameObject.Find("Blank2");
        Blank3 = GameObject.Find("Blank3");
        SetCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCard()
    {
        SelectedBttnList[0].transform.position = Blank1.transform.position;
        var bg1 = SelectedBttnList[0].transform.GetChild(0);
        bg1.GetComponent<RectTransform>().sizeDelta = size;

        SelectedBttnList[1].transform.position = Blank2.transform.position;
        var bg2 = SelectedBttnList[1].transform.GetChild(0);
        bg2.GetComponent<RectTransform>().sizeDelta = size;

        SelectedBttnList[2].transform.position = Blank3.transform.position;
        var bg3 = SelectedBttnList[2].transform.GetChild(0);
        bg3.GetComponent<RectTransform>().sizeDelta = size;

    }
}
