using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class JsonEpi1 : MonoBehaviour
{
    int speechNum = 0;
    public JEpi1Class jtc2;
    //public GameObject speechBubble;
    public Text StudyBoard;

    //변경할 변수
    public float delay;
    public float Skip_delay;
    public int cnt;

    //타이핑효과 변수
    public string[] fulltext;
    public int dialog_cnt;
    string currentText;

    //타이핑확인 변수
    public bool text_exit;
    public bool text_full;
    public bool text_cut;

    // Start is called before the first frame update
    void Start()
    {
        //JEpi1Class Jepi1 = new JEpi1Class(true);
        //string jsonData = ObjectToJson(Jepi1);    
        //Debug.Log(jsonData);

        jtc2 = LoadJsonFile<JEpi1Class>(Application.dataPath, "JEpi1Class");
        StudyBoard.text = jtc2.Epi1[speechNum];
        jtc2.SplitList();

        //CreateJsonFile(Application.dataPath, "JEpi1Class", jsonData);     //제이슨 파일 만드는 코드

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(speechNum == jtc2.Epi1.Count-1)
            {
                StudyBoard.text = jtc2.Epi1[jtc2.Epi1.Count-1];
            }
            else
            {
                speechNum++;
                StudyBoard.text = jtc2.Epi1[speechNum];
            }
            
        }
    }

    [System.Serializable]

    public class JEpi1Class
    {
        
        public List<string> Epi1 = new List<string>();
        //public List<string> Typer = new List<string>();
        public string [] Typer;
        public string [] temp;
        public JEpi1Class() { }

        public JEpi1Class(bool isSet)
        {

            if (isSet)
            {
                Epi1.Add("이제 휴대폰, 컴퓨터, 인터넷은 우리 삶의 일부가 되었습니다. ");
                Epi1.Add("우리는 이러한 새로운 생활 환경, " +
                    "즉 디지털 환경에서 수많은 사람들과 다양한 방식으로 교류하는 세상에서" +
                    " 살고 있습니다.");
                Epi1.Add("그러나 우리는 이러한 디지털 세상에서 살아가는 방법, " +
                    "사람들과 교류하는 방법을 아직 잘 모릅니다. ");
                Epi1.Add("우리는 디지털 세상에서 안전하고 평등하게 살아가는 법을 배워야 합니다.");

            }
        }

        public void SplitList()
        {
            int i;
            for (i = 0; i < Epi1.Count; i++)
            {
                Typer = Epi1[i].Split();
            }

        }



    }

    //IEnumerator ShowText(string[] _fullText)
    //{
    //    //기존문구clear
    //    StudyBoard.text = "";
    //    //타이핑 시작
    //    for (int i = 0; i < _fullText[cnt].Length; i++)
    //    {
    //        //타이핑중도탈출
    //        if (_fullText[i] == ".")
    //        {
    //            break;
    //        }
    //        //단어하나씩출력
    //        StudyBoard.text = _fullText[cnt].Substring(0, i + 1);
    //        this.GetComponent<Text>().text = StudyBoard.text;
    //        yield return new WaitForSeconds(delay);
    //    }
    //    //탈출시 모든 문자출력
    //    Debug.Log("Typing 종료");
    //    this.GetComponent<Text>().text = _fullText[cnt];
    //    yield return new WaitForSeconds(Skip_delay);

    //    //스킵_지연후 종료
    //    Debug.Log("Enter 대기");
    //    text_full = true;
    //}


    string ObjectToJson(object obj)     //오브젝트를 문자열로 된 JSON데이터로 변환하여 반환한다.
    {
        return JsonUtility.ToJson(obj);
    }

    T JsonToOject<T>(string jsonData)   //문자열로 된 JSON데이터를 받아서 원하는 타입의 객체로 변환한다.
    {
        return JsonUtility.FromJson<T>(jsonData);
    }

    void CreateJsonFile(string createPath, string fileName, string jsonData)    //문자열로 만드 JSON 데이터를 파일로 저장하는 코드
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    T LoadJsonFile<T>(string loadPath, string fileName)     //JSON파일을 읽어서 오브젝트로 변환하는 코드.
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }

    //출처: https://wergia.tistory.com/164 [베르의 프로그래밍 노트]
 

}
