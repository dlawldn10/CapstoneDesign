using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPrefab : MonoBehaviour
{
    void Awake()
    {
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());  //캔버스 아래에 프리팹 생성되도록 함.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
