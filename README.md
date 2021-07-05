## CapstoneDesign
### 2021 서울여자대학교 디지털미디어학과 캡스톤 디자인 설계
### 에듀투젠더팀: 기획 - 송채영, 디자인 - 양예원, 개발 - 임지우
#### 디지털 성폭력 예방 교육 애플리케이션 - Unity/Android
##### 1. 대중매체의 빠른 발전에 따라 인터넷을 접하는 나이가 점점 어려지면서 청소년들의 디지털 성범죄 사례가 급증
##### 2. 이에 초등학생 고학년을 대상으로 실생활에 필요한 디지털 성범죄 예방 교육을 제공하는 어플리케이션을 제작
##### 3. 실감미디어 기반 학습을 통한 실제 상황에서의 대처 능력을 향상시키고 디지털 성범죄 예방에 기여하고자 함

https://www.youtube.com/embed/7lsH6LrgQqg

<img width="983" alt="목업" src="https://user-images.githubusercontent.com/69448918/124507563-fa936380-de08-11eb-825e-9b6588721600.png">

---
#### • 초등학생 눈높이에 맞춘 사례 설명
씬마다 필요한 말풍선들을 특정 오브젝트 아래에 배치하여, 일정 시간 간격으로 말풍선들이 차례대로 표시되도록 함.
```C#
    InvokeRepeating("PhoneChat", 1, 2);
    
    public void PhoneChat()
    {
        Phone.transform.GetChild(chatNum).gameObject.SetActive(true);   //다음 채팅 표시
        chatNum++;
    }
```
<img src= "https://user-images.githubusercontent.com/69448918/115139335-4afdef00-a06c-11eb-827d-c8f6aab594f3.gif" width="600px">


---
#### • Unity Android 플러그인사용한 직접 신고해보기 활동
안드로이드 플러그인을 사용하여 기본적인 STT(Speach To Text) 구현.

녹음 버튼을 누른 후 화면에 주어진 말을 따라 말하면 그것을 인식하여 화면에 문자로 출력.
#### <img src="https://user-images.githubusercontent.com/69448918/115139372-80a2d800-a06c-11eb-9966-60fdf9c731ac.gif" width="600px">
---
#### • 카카오톡 챗봇을 사용한 디지털 성범죄 모의 상황과 대처훈련
카카오 i 오픈빌더 가입 후, 카카오톡 채널 및 챗봇 구성.

실제 채팅앱을 사용하여 디지털 성범죄가 발생 할 수 있는 환경과 발화를 모의 상황을 통해 경험하고, 그에 대처하기 위한 적절한 답변을 학습. 
#### <img src="https://user-images.githubusercontent.com/69448918/115139239-b85d5000-a06b-11eb-9cd4-bbd59f255198.gif" width="600px">
---
#### • Vuforia의 AR 기술을 이용한 캐릭터 설명 AR 콘텐츠
교육 초반부 사용자의 흥미 유발 및 몰입감 강화를 위한 교구 이용 AR 콘텐츠.
#### <img src="https://user-images.githubusercontent.com/69448918/123192303-91911f00-d4dd-11eb-9352-678873bb0566.jpg" width="400px"> <img src="https://user-images.githubusercontent.com/69448918/123192306-92c24c00-d4dd-11eb-8ed3-f2b7e21225a0.jpg" width="400px"> 
---
#### • 흐림효과 셰이더를 사용한 '나 이외의 인물 모자이크 하기' 활동
흐림효과 셰이더를 적용한 이미지 프리팹을 터치 드래그 시 생성하여 모자이크 효과.
#### <img src= "https://user-images.githubusercontent.com/69448918/123193317-83440280-d4df-11eb-94a3-c22d18e26cba.gif" width="600px">
---
#### • 직접 불법촬영 예방 포스터 만들어보기
##### 원하는 스티커를 롱터치 후 드래그 하여 원하는 위치로 이동
Time.deltaTime을 사용하여 클릭 시간 측정, 롱클릭 시 오브젝트를 캔버스로 계층을 옮긴 후 해당 창을 닫음.
```C#
private void Update()
    {
        if (isBtnDown)
        {
            clickTime += Time.deltaTime;
            if(clickTime > 1)   //1초 롱클릭 시
            {
                
                if (phraseSV != null)   
                {
                    //창닫기
                    this.gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
                    Destroy(phraseSV);
                }

                longClicked = true;
                
            }
        }
    }
```
드래그 코드
```C#
    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
        this.clickTime = 0; //터치 시간 초기화
        longClicked = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (longClicked == true)
        {
            //드래그
            Vector2 currentPos = Input.mousePosition;
            this.transform.position = currentPos;
        }
        
    }
```
# <img src= "https://user-images.githubusercontent.com/69448918/123191532-5cd09800-d4dc-11eb-891d-4bfe4139f6a2.jpg" width="400px"> <img src="https://user-images.githubusercontent.com/69448918/123191539-5f32f200-d4dc-11eb-8522-8febbf5b93ba.jpg" width="400px">
##### 원하는 색과 굵기를 선택하여 그림그리기
# <img src="https://user-images.githubusercontent.com/69448918/123191540-61954c00-d4dc-11eb-808b-df24853e5016.jpg" width="400px">
##### 완성된 포스터를 내 갤러리에 저장
# <img src="https://user-images.githubusercontent.com/69448918/123191547-635f0f80-d4dc-11eb-9cb1-997c22398c94.jpg" width="400px">
완성된 포스터 화면 전체를 캡처하여 로컬 갤러리에 저장.
```C#
//스크린샷 찍기
    IEnumerator CRSaveScreenshot() 
    {
        onCapture = true;   
        
        yield return new WaitForEndOfFrame();
        
        ...//권한허락 후
        
        string persistentDataPath = Application.persistentDataPath;
        string fileLocation = persistentDataPath.Substring(0, persistentDataPath.IndexOf("Android")) + "/DCIM/EduToGender";     //사진 저장할 경로 지정
        string filename = Application.productName + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";    //저장할 파일 이름 지정
        string finalLOC = fileLocation + filename;  //파일명 추가된 저장경로명
        if (!Directory.Exists(fileLocation))    //저장경로에 해당 파일 없으면 파일 만들기
        {
            Directory.CreateDirectory(fileLocation);
        }

        byte[] imageByte; //스크린샷을 Byte로 저장.Texture2D use 
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);  //스크린샷 사이즈 설정.

        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);    //픽셀 읽기
        tex.Apply();    //읽은 픽셀 텍스쳐 저장

        imageByte = tex.EncodeToPNG();  //png로 변환
        DestroyImmediate(tex);  //다 쓴 텍스쳐 삭제하기
        File.WriteAllBytes(finalLOC, imageByte);    //캡쳐한 이미지 finalLoc에 저장.

        
        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + finalLOC) });
        objActivity.Call("sendBroadcast", objIntent);


        //효과음 재생
        this.gameObject.GetComponent<AudioSource>().Play();
        //토스트 메세지 띄우기
        toast._ShowAndroidToastMessage("캡쳐되었습니다");
        toast._ShowAndroidToastMessage(finalLOC + "에 저장되었습니다");
        onCapture = false;
    }
```




