using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Kvantik1 : MonoBehaviour
{
    public GameObject child;
    public GameObject myObj;
    public Transform parent;
    private AudioSource audioSource;
    public AudioClip audioa;
    private VideoPlayer video;

    public bool click = true;

    private void Awake()
    {
        audioSource = child.GetComponent<AudioSource>();
        video = myObj.GetComponent<VideoPlayer>();
    }
    public void kvantik()
    {

        if(click == true)
        {
            myObj.gameObject.SetActive(false);
            child.gameObject.SetActive(true);
            child.transform.position = new Vector3(0,0,0);
            child.transform.rotation = new Quaternion(0, 180, 0, 0);
            child.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            child.transform.SetParent(parent, false);
            video.Pause();
            audioSource.clip = audioa;
            audioSource.Play();
            StartCoroutine(payse());
        }

        if (click == false)
        {
            myObj.SetActive(true);
            child.SetActive(false);
            child.transform.SetParent(null);
            video.Play();
            click = true;
        }

    }
    IEnumerator payse()
    {
        yield return new WaitForSeconds(1);
        click = false;
    }

}
