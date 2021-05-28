using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.SetParent(GameObject.Find("NavBar").transform, false);
    }

}
