using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isAnswer : MonoBehaviour
{
    private string myAnswer;
    public GameObject Ocanvas;
    public GameObject Xcanvas;
    int QuestionNumber;

    public GameObject QList;
    public GameObject nextBttn;

    public GameObject Obttn;
    public GameObject Xbttn;

    public AudioClip CorrectSound;
    public AudioClip WrongSound;

    List<string> Answers = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        QuestionNumber = 1;
        Ocanvas.SetActive(false);
        Xcanvas.SetActive(false);
        QList = GameObject.Find("Quizes");
        Answers.Add("X");
        Answers.Add("O");
        Answers.Add("X");
        Answers.Add("X");
        nextBttn.SetActive(false);
    }

    public void setAnswerO()
    {
        this.myAnswer = "O";
        isCorrect();
    }

    public void setAnswerX()
    {
        this.myAnswer = "X";
        isCorrect();
    }

    public void isCorrect()
    {

        if (myAnswer == Answers[QuestionNumber - 1])   //내답 = 정답이면
        {
            Correct();
        }
        else
        {
            Wrong();
        }

    }

    public void Correct()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(CorrectSound);
        Ocanvas.SetActive(true);
        QuestionNumber += 1;
        Invoke("InActivateCanvas_O", 2);
        if(QuestionNumber == 5)
        {
            nextBttn.SetActive(true);
            Obttn.GetComponent<Button>().interactable = false;
            Xbttn.GetComponent<Button>().interactable = false;
        }
        else
        {
            ShowNextQuiz();
        }
        
    }

    public void Wrong()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(WrongSound);
        Xcanvas.SetActive(true);
        Invoke("InActivateCanvas_X", 2);
    }

    public void InActivateCanvas_O()
    {
        Ocanvas.SetActive(false);
    }

    public void InActivateCanvas_X()
    {
        Xcanvas.SetActive(false);
    }

    public void ShowNextQuiz()
    {
        QList.transform.GetChild(QuestionNumber - 2).gameObject.SetActive(false);
        QList.transform.GetChild(QuestionNumber - 1).gameObject.SetActive(true);
    }
}
