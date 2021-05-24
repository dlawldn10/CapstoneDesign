using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickerLongClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isBtnDown = false;
    private float clickTime = 0;    //클릭중인 시간

    GameObject stickerSV;


    private void Start()
    {
        stickerSV = GameObject.Find("StickerScrollView");
    }


    private void Update()
    {
        if (isBtnDown)
        {
            
            clickTime += Time.deltaTime;
            if(clickTime > 1)
            {
                

                //창닫기
                if (stickerSV.activeSelf)
                {
                    //선택
                    this.gameObject.transform.parent = GameObject.Find("Canvas").transform;
                    stickerSV.SetActive(false);
                }

                //드래그
                Vector2 currentPos = Input.mousePosition;
                this.transform.position = currentPos;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
        clickTime = 0;
    }
}
