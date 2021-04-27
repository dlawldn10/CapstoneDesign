using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//꼭 캔버스에 스크립트 넣기
public class makeBlur : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject effect;

    public void OnBeginDrag(PointerEventData eventData)
    {
       

    }

    public void OnEndDrag(PointerEventData eventData)
    {
       

    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentPos = Input.mousePosition;
        Instantiate(effect, currentPos, Quaternion.identity);

    }
}
