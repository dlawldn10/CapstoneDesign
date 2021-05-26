using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintInstantiate : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    string colorName = "";
    int colorSize = 0;
   
    GameObject Color;
    GameObject emptyObj;
    public GameObject[] RedGroup = new GameObject[3];
    public GameObject[] OrangeGroup = new GameObject[3];
    public GameObject[] YellowGroup = new GameObject[3];
    public GameObject[] GreenGroup = new GameObject[3];
    public GameObject[] YellowgreenGroup = new GameObject[3];
    public GameObject[] BlueGroup = new GameObject[3];
    public GameObject[] SkyblueGroup = new GameObject[3];
    public GameObject[] PurpleGroup = new GameObject[3];
    public GameObject[] BrownGroup = new GameObject[3];
    public GameObject[] BlackGroup = new GameObject[3];
    public GameObject[] WhiteGroup = new GameObject[3];

    public static List<List<GameObject>> paintObjects = new List<List<GameObject>>();
    public static List<GameObject> workList = new List<GameObject>();
    public static Stack<GameObject> st;
    public static int indx = 0;

    private void Start()
    {
        emptyObj = new GameObject();
        GameObject paper = GameObject.Find("Paper");
        emptyObj.transform.SetParent(paper.GetComponent<Transform>());  //Paper 아래에 emptyobj 생성하도록 설정
        workList.Add(emptyObj);
        //Instantiate(emptyObj, paper.transform.position, Quaternion.identity);
        
    }


    public void setColor()
    {
        colorName = PosterBttns.nowColor;
        colorSize = PosterBttns.nowColorSize;
        switch (colorName)
        {
            case "RED":
                Color = RedGroup[colorSize - 1];
                break;
            case "ORANGE":
                Color = OrangeGroup[colorSize - 1];
                break;
            case "YELLOW":
                Color = YellowGroup[colorSize - 1];
                break;
            case "GREEN":
                Color = GreenGroup[colorSize - 1];
                break;
            case "YELLOWGREEN":
                Color = YellowgreenGroup[colorSize - 1];
                break;
            case "BLUE":
                Color = BlueGroup[colorSize - 1];
                break;
            case "SKYBLUE":
                Color = SkyblueGroup[colorSize - 1];
                break;
            case "PURPLE":
                Color = PurpleGroup[colorSize - 1];
                break;
            case "BROWN":
                Color = BrownGroup[colorSize - 1];
                break;
            case "BLACK":
                Color = BlackGroup[colorSize - 1];
                break;
            case "WHITE":
                Color = WhiteGroup[colorSize - 1];
                break;

        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (PosterBttns.isPaintMode)
        {
            setColor();
            Vector2 currentPos = Input.mousePosition;
            GameObject tmp = Instantiate(Color, currentPos, Quaternion.identity);
            tmp.transform.SetParent(emptyObj.GetComponent<Transform>());  //emptyobj 아래에 물감 생성하도록 설정
            


            //paintObjects.Add(new List<GameObject>());
            
            //paintObjects[indx].Add(Instantiate(Color, currentPos, Quaternion.identity));
        }


    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (PosterBttns.isPaintMode)
        {
            //indx++;
            emptyObj = new GameObject();
            emptyObj.transform.SetParent(GameObject.Find("Paper").GetComponent<Transform>());  //Paper 아래에 emptyobj 생성하도록 설정
            workList.Add(emptyObj);
        }
    }
}
