using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMemo : MonoBehaviour
{
    public InputField inputField_Y;
    public InputField inputField_P;
    public InputField inputField_B;

   

    // Start is called before the first frame update
    void Start()
    {
        inputField_Y.text = InputZoom.text_Y;
        inputField_P.text = InputZoom.text_P;
        inputField_B.text = InputZoom.text_B;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
