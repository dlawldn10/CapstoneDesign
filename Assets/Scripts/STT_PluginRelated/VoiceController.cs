using UnityEngine;
using UnityEngine.UI;
//원래는 구글STT를 바로 유니티에서 사용하려고 했으나 안드로이드에서 빌드하면 streraming asset에 바로 접근이 불가해서 key를 얻을 수 없었음 -> STT실행 불가.
//그래서 바로 사용하는 방법 대신 플러그인으로 연결하여 안드로이드 기능을 사용함.

public class VoiceController : MonoBehaviour {

    AndroidJavaObject activity;
    AndroidJavaObject plugin;

    public delegate void OnResultRecieved(string result);
    public static OnResultRecieved resultRecieved;

    private void Start() {
        InitPlugin();
    }

    void InitPlugin() {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        
        activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                plugin = new AndroidJavaObject(
                "com.example.matthew.plugin.VoiceBridge");
        }));

        activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
            plugin.Call("StartPlugin");
        }));
    }

    /// <summary>
    /// gets called via SendMessage from the android plugin GameObject must be called "VoiceController"
    /// </summary>
    /// <param name="recognizedText">recognizedText.</param>
    public void OnVoiceResult(string recognizedText) {
        Debug.Log(recognizedText);
        resultRecieved?.Invoke(recognizedText);
    }

    /// <summary>
    /// gets called via SendMessage from the android plugin
    /// </summary>
    /// <param name="error">Error.</param>
    public void OnErrorResult(string error) {
        Debug.Log(error);
    }

    public void GetSpeech() {
        // Calls the function from the jar file
        activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
            plugin.Call("StartSpeaking");
        }));
    }
}
