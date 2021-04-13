using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectCard_x : MonoBehaviour
{

    Camera _mainCam = null;
    public Image ButtonEffect;

    /// 마우스가 다운된 오브젝트
    /// 
    private GameObject target;
    

    //4.x 버전에서는 'void Start()'로 바꿔 주세요.
    void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame 
    void Update()
    {

        //마우스가 내려갔는지?
        if (true == Input.GetMouseButtonDown(0))
        {
            //타겟을 받아온다.
            target = GetClickedObject();

            if (true == target.CompareTag("Card"))
            {
                target.GetComponent<Button>().targetGraphic.canvasRenderer.SetAlpha(255);
                target = null;
            }

        }
        
    }


    /// 
    /// 마우스가 내려간 오브젝트를 가지고 옵니다.
    /// 
    /// 선택된 오브젝트
    private GameObject GetClickedObject()
    {
        //충돌이 감지된 영역
        RaycastHit hit;
        //찾은 오브젝트
        GameObject target = null;

        //마우스 포이트 근처 좌표를 만든다.
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

        //마우스 근처에 오브젝트가 있는지 확인
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            //있다!

            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }

        return target;
    }
}

