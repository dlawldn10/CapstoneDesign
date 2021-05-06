using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurPrefab : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());  //캔버스 아래에 프리팹 생성되도록 함.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
