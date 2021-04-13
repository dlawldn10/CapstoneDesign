using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputZoom : MonoBehaviour
{
    public GameObject zoomCamera;
    Vector3 firstPos;
    public InputField inputField_Y;
    public InputField inputField_P;
    public InputField inputField_B;

    public static string text_Y;
    public static string text_P;
    public static string text_B;



    // Start is called before the first frame update
    void Start()
    {
        firstPos = zoomCamera.transform.position;
        TouchScreenKeyboard.hideInput = true;
        inputField_Y = GameObject.Find("InputField_Y").GetComponent<InputField>();
        inputField_B = GameObject.Find("InputField_B").GetComponent<InputField>();
        inputField_P = GameObject.Find("InputField_P").GetComponent<InputField>();
        text_Y = null;
        text_P = null;
        text_B = null;
}

    // Update is called once per frame
    void Update()
    {

        if (inputField_Y.isFocused)
        {
            zoomCamera.transform.position = new Vector3(673, 687, -367);
            
        }
        else if (inputField_P.isFocused)
        {
            zoomCamera.transform.position = new Vector3(1569, 687, -367);
            
        }
        else if (inputField_B.isFocused)
        {
            zoomCamera.transform.position = new Vector3(2438, 687, -367);
            
        }
        else
        {
            zoomCamera.transform.position = firstPos;
        }
    }

    public void SaveText_Y()
    {
        text_Y = inputField_Y.text;
    }

    public void SaveText_P()
    {
        text_P = inputField_P.text;
    }

    public void SaveText_B()
    {
        text_B = inputField_B.text;
    }
}
