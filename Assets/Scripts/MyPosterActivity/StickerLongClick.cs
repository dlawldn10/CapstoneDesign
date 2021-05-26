using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickerLongClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isBtnDown = false;
    private float clickTime = 0;    //클릭중인 시간

    GameObject stickerSV;

    bool longClicked = false;


    private void Start()
    {
        stickerSV = GameObject.Find("StickerScrollView(Clone)");
    }


    private void Update()
    {
        if (isBtnDown)
        {
            clickTime += Time.deltaTime;
            if (clickTime > 1)
            {
                //창닫기
                if (stickerSV.activeInHierarchy)
                {
                    //선택
                    this.gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
                    Destroy(stickerSV);
                }

                longClicked = true;

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
        longClicked = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (longClicked == true)
        {
            //드래그
            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
        }

    }
}
