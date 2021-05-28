using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//씬1_3Cards에 적용.
public class SelectedCardNum : MonoBehaviour
{
    public static int selected_card_num = 0;
    public static bool finishedSelecting = false;
    public GameObject NextBttn;
    public GameObject BackBttn;
    public GameObject NextBttn2;
    public GameObject speechBubble;
    public GameObject speechBubble2;
    public GameObject Panel;

    GameObject CanvasScene1_3;

    private void Start()
    {
        CanvasScene1_3 = GameObject.Find("Canvas");
        SelectCard.SceneChanged = false;
        selected_card_num = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(selected_card_num == 3)  //카드 3개 골랐을때
        {
            NextBttn.SetActive(true);
            finishedSelecting = true;
        }
        else if(selected_card_num < 3)   //카드 3개 아직 다 안골랐을때
        {
            NextBttn.SetActive(false);
            finishedSelecting = false;
        }
    }

    public void Scene1_3_NextBttn()
    {
        GameObject soundPlayer = GameObject.Find("SoundPlayer");
        soundPlayer.SendMessage("plainBttnClick");
        SelectCard.SceneChanged = true;
        speechBubble.SetActive(false);
        speechBubble2.SetActive(true);
        NextBttn.SetActive(false);
        NextBttn2.SetActive(true);
        BackBttn.SetActive(false);
        Panel.SetActive(true);
        DontDestroyOnLoad(CanvasScene1_3);
    }

    public void Scene1_4_NextBttn()
    {
        Destroy(GameObject.Find("Canvas"));
    }
}
