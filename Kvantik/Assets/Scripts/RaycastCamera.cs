using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class RaycastCamera : MonoBehaviour
{
    public GameObject[] CausticToys;
    private int toyCau;

    public VideoClip oneVideo;
    public VideoClip twoVideo;
    public GameObject plane;

    Vector3 centreRay = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    private bool Switching = true;
    Animator myAnim;
    [@SerializeField] private string switchAnim;
    [@SerializeField] private string animationSwitchTwo;
    public Material glow;
    public Material normalMat;
    public GameObject postProc;

    
    [@SerializeField] private string Plane1;
    [@SerializeField] private string OnDisPlane1;
    public GameObject neiron;

    private void Awake()
    {
        
    }

    [Obsolete]
    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Ray rayTouch = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 1));
            RaycastHit hitTouch;


            if (Physics.Raycast(rayTouch, out hitTouch, Mathf.Infinity))
            {
                if (hitTouch.transform.tag == "ChristmasTrees")
                {
                    toyCau = Random.Range(0, CausticToys.Length);
                    CausticToys[toyCau].SetActive(true);
                    
                }

               
                if (hitTouch.transform.tag == "NextPage5")
                {
                    VideoPlayer vp = plane.GetComponent<VideoPlayer>();
                    vp.Stop();
                    vp.clip = twoVideo;
                    vp.Play();

                }

                if (hitTouch.transform.tag == "BackPage5")
                {
                    VideoPlayer vp = plane.GetComponent<VideoPlayer>();
                    vp.Stop();
                    vp.clip = oneVideo;
                    vp.Play();
                }


                //Page10
                if(hitTouch.transform.tag == "Switch")
                {
                    GameObject page10 = GameObject.FindWithTag("Page10");
                    

                    if (Switching == true)
                    {
                        postProc.SetActive(true);
                        page10.transform.FindChild("pCylinder16").GetComponent<MeshRenderer>().material = glow;
                        StartCoroutine(payse());
                        
                    }
                    else
                    {
                        postProc.SetActive(false);
                        page10.transform.FindChild("pCylinder16").GetComponent<MeshRenderer>().material = normalMat;
                        StartCoroutine(payseMM());
                    }
                    
                }



                //Page12
                if (hitTouch.transform.tag == "Plane1")
                {
                    StartCoroutine(payse1());
                }

                if ((hitTouch.transform.tag != "Plane1") && (myAnim == neiron.transform.FindChild("Plane1").GetComponent<Animator>()))
                {
                    myAnim.Play(OnDisPlane1);
                    
                    StartCoroutine(rebind(myAnim));
                    myAnim = new Animator();
                }

                if (hitTouch.transform.tag == "Plane2")
                {
                    StartCoroutine(payse2());
                }

                if ((hitTouch.transform.tag != "Plane2") && (myAnim == neiron.transform.FindChild("Plane2").GetComponent<Animator>()))
                {
                    myAnim.Play(OnDisPlane1);
                  
                    StartCoroutine(rebind(myAnim));
                    myAnim = new Animator();
                  
                }

                if (hitTouch.transform.tag == "Plane3")
                {
                    StartCoroutine(payse3());
                }

                if ((hitTouch.transform.tag != "Plane3") && (myAnim == neiron.transform.FindChild("Plane3").GetComponent<Animator>()))
                {
                    myAnim.Play(OnDisPlane1);
                    
                    StartCoroutine(rebind(myAnim));
                    myAnim = new Animator();
                   
                }
            }

        }

    }


    IEnumerator rebind(Animator animator)
    {
        yield return new WaitForSeconds(0.5f);
        animator.Rebind();
    }

    [System.Obsolete]
    IEnumerator payse1()
    {
        yield return new WaitForSeconds(0.1f);

        myAnim = neiron.transform.FindChild("Plane1").GetComponent<Animator>();

        myAnim.Play(Plane1);

    }

    [System.Obsolete]
    IEnumerator payse2()
    {
        yield return new WaitForSeconds(0.1f);

        myAnim = neiron.transform.FindChild("Plane2").GetComponent<Animator>();

        myAnim.Play(Plane1);
  
    }

    [System.Obsolete]
    IEnumerator payse3()
    {
        yield return new WaitForSeconds(0.1f);

        myAnim = neiron.transform.FindChild("Plane3").GetComponent<Animator>();

        myAnim.Play(Plane1);
    }

    IEnumerator payse()
    {
        yield return new WaitForSeconds(0.1f);
        Switching = false;
    }

    IEnumerator payseMM()
    {
        yield return new WaitForSeconds(0.1f);
        Switching = true;
    }

    

}
