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
        //카카오톡 여는 코드
        //AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        //AndroidJavaObject pm = jo.Call<AndroidJavaObject>("getPackageManager");
        //AndroidJavaObject intent = pm.Call<AndroidJavaObject>("getLaunchIntentForPackage", "com.kakao.talk");
        //jo.Call("startActivity", intent);

        //에듀투젠더 채널로 바로가기 링크로 변경.
        Application.OpenURL("http://pf.kakao.com/_FNxeHK");

    }

    
}
