using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toCapture : MonoBehaviour
{
    public GameObject nextBttn1;
    public GameObject nextBttn2;

    public GameObject Tools;
    public GameObject nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void nextBttn_4_34()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        Tools.SetActive(false);
        nextScene.SetActive(true);
        nextBttn1.SetActive(false);
        nextBttn2.SetActive(true);
        GameObject tmp = GameObject.Find("Palette");
        if (tmp.activeSelf)
        {
            tmp.SetActive(false);
        }
        if (GameObject.Find("PhraseScrollView(Clone)") != null)
        {
            Destroy(GameObject.Find("PhraseScrollView(Clone)"));
        }
        if (GameObject.Find("StickerScrollView(Clone)") != null)
        {
            Destroy(GameObject.Find("StickerScrollView(Clone)"));
        }
    }

}
