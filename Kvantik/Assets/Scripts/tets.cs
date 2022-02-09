using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tets : MonoBehaviour
{
    public GameObject test;
    public GameObject quize;
    public GameObject myObj;

    public bool click = true;

    public void kvantik()
    {

        if(click == true)
        {
            myObj.gameObject.SetActive(false);
            quize.SetActive(true);
            test.SetActive(true);
            StartCoroutine(payse());
        }

        if (click == false)
        {
            myObj.SetActive(true);
            quize.SetActive(false);
            test.SetActive(false);
            click = true;
        }

    }
    IEnumerator payse()
    {
        yield return new WaitForSeconds(1);
        click = false;
    }

}
