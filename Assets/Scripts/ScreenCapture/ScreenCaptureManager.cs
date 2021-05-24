//using DeadMosquito.AndroidGoodies;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

// 안드로이드 스튜디오는 매니페스트 선언필요.  <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
//https://answers.unity.com/questions/200173/android-how-to-refresh-the-gallery-.html
public class ScreenCaptureManager : MonoBehaviour
{
    bool onCapture = false;
    public ToastMssg toast;
    

    private void Start()
    {
        toast = GameObject.Find("Toast").GetComponent<ToastMssg>();

    }

    public void PressBtnCapture()
    {
        if (onCapture == false)
        {
            StartCoroutine("CRSaveScreenshot");
            
        }
    }

    //스크린샷 찍는 함수
    IEnumerator CRSaveScreenshot() 
    {
        onCapture = true;   //캡쳐작업중.
        
        yield return new WaitForEndOfFrame();

        if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite) == false)   //사용자 저장공간 접근 권한 없으면,
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);  //권한 허락 받기.

            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil(() => Application.isFocused == true);

            if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite) == false)   //사용자가 첫번째 물어봤을때 거절하면
            {
                
                OpenAppSetting();

                onCapture = false;
                yield break;
            }
        }
        string persistentDataPath = Application.persistentDataPath;
        string fileLocation = persistentDataPath.Substring(0, persistentDataPath.IndexOf("Android")) + "/DCIM/EduToGender";     //사진 저장할 경로 지정
        //persistentDataPath.Substring(0, persistentDataPath.IndexOf("Android")) + "/DCIM/";
        //"mnt/sdcard/DCIM/Screenshots/" -> 이걸로 하다가 갑자기 안돼서 위에걸로 바꿈...
        string filename = Application.productName + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        string finalLOC = fileLocation + filename;
        if (!Directory.Exists(fileLocation))    //저장경로에 해당 파일 없으면 파일 만들기.
        {
            Directory.CreateDirectory(fileLocation);
            
        }

        byte[] imageByte; //스크린샷을 Byte로 저장.Texture2D use 
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);  //여기서 스크린샷 사이즈 설정.

        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);    //이만큼 픽셀 읽기.
        tex.Apply();    //읽은 픽셀 텍스쳐 저장

        imageByte = tex.EncodeToPNG();  //png로 변환
        DestroyImmediate(tex);  //다 쓴 텍스쳐 삭제하기. 
        //text2.text = "여기까지 진행";
        File.WriteAllBytes(finalLOC, imageByte);    //캡쳐한 이미지 finalLoc에 저장.

        
        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + finalLOC) });
        objActivity.Call("sendBroadcast", objIntent);


        //토스트 메세지 띄우기
        toast._ShowAndroidToastMessage("캡쳐되었습니다");
        toast._ShowAndroidToastMessage(finalLOC + "에 저장되었습니다");
        onCapture = false;
    }


    // https://forum.unity.com/threads/redirect-to-app-settings.461140/
    private void OpenAppSetting()
    {
        try
        {
#if UNITY_ANDROID
            using (var unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivityObject = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                string packageName = currentActivityObject.Call<string>("getPackageName");

                using (var uriClass = new AndroidJavaClass("android.net.Uri"))
                using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("fromParts", "package", packageName, null))
                using (var intentObject = new AndroidJavaObject("android.content.Intent", "android.settings.APPLICATION_DETAILS_SETTINGS", uriObject))
                {
                    intentObject.Call<AndroidJavaObject>("addCategory", "android.intent.category.DEFAULT");
                    intentObject.Call<AndroidJavaObject>("setFlags", 0x10000000);
                    currentActivityObject.Call("startActivity", intentObject);
                }
            }
#endif
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    
}