using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setAR_UI : MonoBehaviour
{
    public GameObject ARui;
    //public GameObject mainCam;
    public GameObject notARui;
    
    //public GameObject AR_Bear;

   

    // Start is called before the first frame update
    void Start()
    {
        
        notARui.SetActive(true);
        ARui.SetActive(false);
    }

    
    public void SetAR_UI()
    {
        notARui.SetActive(false);
        ARui.SetActive(true);
        //mainCam.SetActive(false);
        
    }

    

}
