using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각 화면전환 버튼에다가 적용할 스크립트
public class SoundEffects : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip planeBttnSound;
    public AudioClip startBttnSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void plainBttnClick()
    {
        audioSource.PlayOneShot(planeBttnSound);
        //StartCoroutine("DestroyDelay");
    }

    public void startBttnClick()
    {
        audioSource.PlayOneShot(startBttnSound);
        //StartCoroutine("DestroyDelay");
    }



    IEnumerator DestroyDelay()
    {
        yield return new WaitUntil(()=> !audioSource.isPlaying);
        Destroy(this.gameObject);
    }
}
