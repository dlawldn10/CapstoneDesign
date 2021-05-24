using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanelDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitNo()
    {
        Time.timeScale = 1f; 
        Destroy(this.gameObject);
    }
}
