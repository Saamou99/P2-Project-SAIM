using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionBehavior : MonoBehaviour
{

    public TMP_InputField MainInputField;
    [SerializeField] private TMP_InputField[] MainInputFields;
    [SerializeField] private string myText;
    public string RightAnswer;
    public string[] RightAnswers;
    public GameObject[] GDQuestionArray;
    public GameObject[] GDFinishedQuestions = new GameObject[10];
    [SerializeField]
    public GameObject[] GeoQuestionArray;
    public GameObject[] GeoFinishedQuestions = new GameObject[10];

    public GameObject[] KSQuestionArray;
    public GameObject[] KSFinishedQuestions = new GameObject[10];

    public GameObject[] FraQuestionArray;
    public GameObject[] FraFinishedQuestions = new GameObject[10];


    [SerializeField] private GameObject[] HintButtons;
    [SerializeField] private GameObject[] HintPanels;
    


    public GameManager GameManager;

    public void CheckRightAnswer(int answerArray)
    {
        myText = MainInputField.text;
        RightAnswer = RightAnswers[answerArray];
        

        if (myText==RightAnswer)
        {
            Debug.Log("Correct");
            Destroy(GameObject.FindWithTag("Answer"));
            GameManager.AnswerCorrectly();
        }
        else
        {
            Debug.Log("Wrong!");
        }

    }

    public void SpawnGDQuestion()
    {
        SpawnTheQuestion(GDQuestionArray,GDFinishedQuestions);
        SpawnHintButton(0);
    }

    public void SpawnGeoQuestion()
    {
        SpawnTheQuestion(GeoQuestionArray,GeoFinishedQuestions);
        SpawnHintButton(1);
    }

    public void SpawnKSQuestion()
    {
        SpawnTheQuestion(KSQuestionArray, KSFinishedQuestions);
        SpawnHintButton(2);
    }

    public void SpawnFraQuestion()
    {
        SpawnTheQuestion(FraQuestionArray, FraFinishedQuestions);
        SpawnHintButton(3);
    }


    private void SpawnTheQuestion(GameObject[] array, GameObject[] finishedQuestions)
    {

        var questionIndex = Random.Range(0, array.Length);
        var answerIndex = questionIndex;
        
        
        while (finishedQuestions[questionIndex] != null)
        {
            questionIndex = Random.Range(0, array.Length);
        }
        array[questionIndex].SetActive(true);
        finishedQuestions[questionIndex] = array[questionIndex];
    }


    public void SelectAnInputField(int fieldIndex)
    {
        MainInputField = MainInputFields[fieldIndex];
    }
    
    private void SpawnHintButton(int index)
    {
        HintButtons[index].SetActive(true);
    }
    
    public void SpawnHintPanel(int index)
    {
        if (!HintPanels[index].activeInHierarchy)
        {
            HintPanels[index].SetActive(true);
        }
        else
        {
            HintPanels[index].SetActive(false);
        }
    }

    
    public void ActivateQuestion(int index)
    {
        if (!GDQuestionArray[index].activeInHierarchy || !GeoQuestionArray[index].activeInHierarchy || !FraQuestionArray[index].activeInHierarchy || !KSQuestionArray[index].activeInHierarchy)
        {
            GameObject.FindGameObjectWithTag("Question").SetActive(true);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Question").SetActive(true);
        }

        
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
