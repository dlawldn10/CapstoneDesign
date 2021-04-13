using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    public int AreaWidth = 500;
    public int AreaHeight = 500;
    public static Vector2 defaultposition;//드롭하면 다시 원위치로 보내기위한 변수
    public Transform Area1;
    public Transform Area2;
    public Transform Area3;
    public Transform Area4;
    float radius;
    
    
    
    private void Start()
    {
        
        radius = Mathf.Sqrt((AreaHeight * AreaHeight) + (AreaWidth * AreaWidth)) / 2;

    }
    void Update()
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Input.mousePosition; 
        this.transform.position = currentPos;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultposition = this.transform.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //this.transform.position = defaultposition;  //원래장소로 돌아가기
        Vector2 currentPos = Input.mousePosition;
        //this.transform.position = currentPos;
        if (Vector3.Distance(currentPos, Area1.position) < radius)
        {
            this.transform.position = Area1.transform.position;
        }
        else if (Vector3.Distance(currentPos, Area2.position) < radius)
        {
            this.transform.position = Area2.position;
        }
        else if (Vector3.Distance(currentPos, Area3.position) < radius)
        {
            this.transform.position = Area3.position;
        }
        else if (Vector3.Distance(currentPos, Area4.position) < radius)
        {
            this.transform.position = Area4.position;
        }

    }

    //public Renderer rend;
    //void Start()
    //{
    //    rend = GetComponent<Renderer>();
    //}
    //void OnMouseDrag()
    //{
    //    rend.material.color -= Color.white * Time.deltaTime;
    //}
}
