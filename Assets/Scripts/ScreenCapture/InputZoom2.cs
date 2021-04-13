using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputZoom2 : MonoBehaviour
{
    public GameObject zoomCamera;
    Vector3 firstPos;
    public InputField inputField_Line1;
    public InputField inputField_Line2;
    public InputField inputField_Line3;

    public InputField inputField_Date;
    public InputField inputField_Name;

    

    // Start is called before the first frame update
    void Start()
    {
        firstPos = zoomCamera.transform.position;
        TouchScreenKeyboard.hideInput = false;
        //inputField_Line1 = GameObject.Find("InputField_Line1").GetComponent<InputField>();
        //inputField_Line3 = GameObject.Find("InputField_Line2").GetComponent<InputField>();
        //inputField_Line2 = GameObject.Find("InputField_Line3").GetComponent<InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (inputField_Line1.isFocused)
        {
            zoomCamera.transform.position = new Vector3(-1.4f, -22f, 37.3f);
            
        }
        else if (inputField_Line2.isFocused)
        {
            zoomCamera.transform.position = new Vector3(-1.4f, -32f, 37.3f);
            
        }
        else if (inputField_Line3.isFocused)
        {
            zoomCamera.transform.position = new Vector3(-1.4f, -42f, 37.3f);
            
        }
        else if (inputField_Date.isFocused)
        {
            zoomCamera.transform.position = new Vector3(-8.8f, -44.3f, 58.1f);

        }
        else if (inputField_Name.isFocused)
        {
            zoomCamera.transform.position = new Vector3(29.3f, -44.3f, 58.1f);

        }
        else
        {
            zoomCamera.transform.position = firstPos;
        }
    }

}
