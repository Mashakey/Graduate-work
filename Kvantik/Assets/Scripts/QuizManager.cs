using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject OUTPanel;
    public GameObject testPage;

    public Text QuestionText;
    public Text ScoreText;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        OUTPanel.SetActive(false);
        generateQuestion();
    }

    //public void EndQuiz()
    //{
    //    testPage.SetActive(false);
    //}
    
     void GameOver()
    {
        StartCoroutine(over());
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().isCurrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswersScript>().isCurrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;

            SetAnswers();
        }
        else
        {
            GameOver();

        }
    }
    
    IEnumerator over()
    {
        yield return new WaitForSeconds(0.02f);

        Quizpanel.SetActive(false);
        OUTPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestions;
    }
}
