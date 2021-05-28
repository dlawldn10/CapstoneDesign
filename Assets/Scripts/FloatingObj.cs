using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObj : MonoBehaviour
{
    public int floatInterval = 50;
    public float floatingSpeed = 1;
    Vector2 thisObjPos;
    bool isGoingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        thisObjPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoingUp == true)
        {
            this.gameObject.transform.Translate(Vector3.up * floatingSpeed);
        }
        else
        {
            this.gameObject.transform.Translate(Vector3.down * floatingSpeed);
        }


        if (thisObjPos.y + floatInterval == this.gameObject.transform.position.y)
        {
            isGoingUp = false;
        }
        else if (thisObjPos.y == this.gameObject.transform.position.y)
        {
            isGoingUp = true;
        }
        
    }
}
