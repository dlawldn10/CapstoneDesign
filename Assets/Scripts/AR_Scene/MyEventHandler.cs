using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEventHandler : DefaultTrackableEventHandler
{
    public GameObject AR_Bear;

    public AudioSource laugh_as;
    public AudioSource Cam_as;

    public GameObject BlinkTxt;

    
    protected override void OnTrackingFound()
    {
        
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);
            var audioComponents = mTrackableBehaviour.GetComponentsInChildren<AudioSource>(true);
            var animationComponents = mTrackableBehaviour.GetComponentsInChildren<Animator>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;

            // Enable audios:
            foreach (var component in audioComponents)
                component.enabled = true;

            // Enable animations:
            foreach (var component in animationComponents)
                component.enabled = true;


            AR_Bear.GetComponent<AudioSource>().Play();
            StopBlink();
            Invoke("Laugh", 9);
            Invoke("TakePic", 10);
        }
    }

    

    public void StopBlink()
    {
        BlinkTxt.GetComponent<Animator>().SetBool("SeeTarget", true);

    }

    IEnumerator Laughing()
    {
        int i = 1;
        laugh_as.Play();
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!laugh_as.isPlaying) //앞선 클립이 끝나면
            {
                i++;
                laugh_as.Play();
                if (i == 2)     //3번 플레이 하면 break;
                    break;

            }
        }
    }

    IEnumerator TakingPic()
    {
        int i = 1;
        Cam_as.Play();
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!Cam_as.isPlaying) //앞선 클립이 끝나면
            {
                i++;
                Cam_as.Play();
                if (i == 3)
                    break;

            }
        }
    }

    public void Laugh()
    {
        //lagh_as.Play();
        StartCoroutine("Laughing");
    }

    public void TakePic()
    {
        //Cam_as.Play();
        StartCoroutine("TakingPic");
    }
}
