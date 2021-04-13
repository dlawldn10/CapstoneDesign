using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//씬1_3각 토글버튼(프리팹)에 적용.
public class SelectCard : MonoBehaviour
{
    Toggle toggle;
    GameObject thisBttn;

    public static bool SceneChanged = false;

    public void Start()
    {
        toggle = this.GetComponent<Toggle>();
        thisBttn = this.GetComponent<GameObject>();
        //card = GameObject.Find("Canvas").GetComponent<SetCards>();

        SetCards.SelectedBttnList.Clear();  //다른 페이지에 있다가 다시 왔을때를 대비해 리스트를 한번 클리어시킨다.
    }

    public void OnClickCard()
    {
        bool test = toggle.isOn;
        if (!SelectedCardNum.finishedSelecting)     //카드선택이 아직 안끝났을때
        {
            
            if (test)   //이 버튼이 토글되면
            {
                SelectedCardNum.selected_card_num++;
            }
            else
            {
                SelectedCardNum.selected_card_num--;
            }

        }else if (SelectedCardNum.finishedSelecting)    //카드선택이 끝났을때
        {
            if (!test)   //이 버튼이 토글되면
            {
                SelectedCardNum.selected_card_num--;
            }
            
        }
        
        
        
    }

    private void Update()
    {
        if (SelectedCardNum.finishedSelecting )  //카드 선택 3개 끝난 상태에서 
        {
            
            if(toggle.isOn == false)    //내가 선택이 안되어있으면
            {
                toggle.interactable = false;
                //this.GetComponent<CardLoad>().enabled = false;

            }
            else     //되어있으면
            {
                toggle.interactable = true;
                //this.GetComponent<CardLoad>().enabled = true;
            }

            if (SceneChanged == true)
            {
                if (toggle.isOn == false)    //내가 선택이 안되어있으면
                {
                    this.gameObject.SetActive(false);
                    //this.GetComponent<CardLoad>().enabled = false;

                }
                else     //되어있으면
                {
                    this.gameObject.SetActive(true);
                    //this.GetComponent<CardLoad>().enabled = true;
                    SetCards.SelectedBttnList.Add(this.gameObject);
                    toggle.isOn = false;
                    

                    
                }
            }

        }
        else
        {
            toggle.interactable = true;
            
        }
        
    }

}

