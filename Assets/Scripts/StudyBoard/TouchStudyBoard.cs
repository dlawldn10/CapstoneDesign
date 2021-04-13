using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStudyBoard : MonoBehaviour
{
    public GameObject StudyBoard;
    int index = 1;  //0은 타이틀.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 currentPos = Input.mousePosition;
        //if(Input.GetMouseButtonDown(0))
        //{
        //    //Debug.Log("click1");


        //}

    }

    public void OnBoard_NextClick()
    {

        StudyBoard.transform.GetChild(index).gameObject.SetActive(false);
        index++;
        if(index == 3)
        {
            StudyBoard.transform.GetChild(0).gameObject.SetActive(false);
        }
        StudyBoard.transform.GetChild(index).gameObject.SetActive(true);
        
    }

    public void OnBoard_BackClick()
    {
        this.gameObject.SetActive(true);
    }

    public void ReTry()     //글교육 페이지에서 쓸 버튼 이벤트 코드
    {
        StudyBoard.transform.GetChild(0).gameObject.SetActive(true);
        StudyBoard.transform.GetChild(index).gameObject.SetActive(false);
        index = 1;    //오디오 다시듣기, 말풍선 리스트 다시 호출.
        StudyBoard.transform.GetChild(index).gameObject.SetActive(true);

    }

}
