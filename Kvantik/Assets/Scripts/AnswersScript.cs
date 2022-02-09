using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswersScript : MonoBehaviour
{
    public bool isCurrect = false;
    public QuizManager quizManager;

    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if (isCurrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Currect Answer");
            quizManager.correct();
            StartCoroutine(nullOut());
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.wrong();
            StartCoroutine(nullOut());
        }
    }

    IEnumerator nullOut()
    {
        yield return new WaitForSeconds(0.1f);

        GetComponent<Image>().color = startColor;
    }
}
