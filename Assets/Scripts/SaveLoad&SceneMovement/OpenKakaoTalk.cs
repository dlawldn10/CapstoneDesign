using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKakaoTalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        


    }

    public void OpenKakao()
    {
        //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

        //AndroidJavaObject pm = jo.Call<AndroidJavaObject>("getPackageManager");

        //AndroidJavaObject intent = pm.Call<AndroidJavaObject>("getLaunchIntentForPackage", "com.kakao.talk");

        //jo.Call("startActivity", intent);

        Application.OpenURL("http://pf.kakao.com/_FNxeHK");

    }

    
}
