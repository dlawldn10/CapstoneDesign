//using DeadMosquito.AndroidGoodies;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Android;

// 안드로이드 스튜디오는 매니페스트 선언필요.  <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
//https://answers.unity.com/questions/200173/android-how-to-refresh-the-gallery-.html
public class ScreenCaptureManager : MonoBehaviour
{
    bool onCapture = false;
    public Animator anim;

    private void Start()
    {
        anim = GameObject.Find("Captured").GetComponent<Animator>();
    }

    public void PressBtnCapture()
    {
        if (onCapture == false)
        {
            anim.SetBool("Capture", true);
            StartCoroutine("CRSaveScreenshot");
            
        }
        //anim.SetBool("Capture", false);
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
                //다이얼로그를 위해 별도의 플러그인을 사용했었다. 이 코드는 주석 처리함.
                //AGAlertDialog.ShowMessageDialog("권한 필요", "스크린샷을 저장하기 위해 저장소 권한이 필요합니다.",
                //"Ok", () => OpenAppSetting(),
                //"No!", () => AGUIMisc.ShowToast("저장소 요청 거절됨"));

                // 별도로 확인 팝업을 띄우지 않을꺼면 OpenAppSetting()을 바로 호출함.
                OpenAppSetting();

                onCapture = false;
                yield break;
            }
        }

        string fileLocation = "mnt/sdcard/DCIM/Screenshots/CapstonDesign/";     //사진 저장할 경로 지정
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

        File.WriteAllBytes(finalLOC, imageByte);    //캡쳐한 이미지 finalLoc에 저장.


        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + finalLOC) });
        objActivity.Call("sendBroadcast", objIntent);

        //아래 한 줄 또한 별도의 안드로이드 플러그인. 별도로 만들어서 호출하는 함수를 넣어주면 된다.
        //AGUIMisc.ShowToast(finalLOC + "로 저장했습니다.");
        anim.SetBool("Capture", false);
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