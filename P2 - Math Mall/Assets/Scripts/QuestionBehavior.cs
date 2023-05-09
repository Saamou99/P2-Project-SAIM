using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject[] HintButtons;
    [SerializeField] private GameObject[] HintPanels;
    [SerializeField] ProgressBar progressBarGD;

    [SerializeField] int correctGDAnswers;
    [SerializeField] int gDQuestionCount;

    public ProgressBar ProgressBarGD
    {
        get => progressBarGD ??= FindObjectOfType<ProgressBar>();
        set => progressBarGD = value;
    }
    
    public GameManager GameManager;

    private void Awake()
    {
        DontDestroyOnLoad(this); // SLET, HVIS ET ANDET GAMEOBJECT SKAL BRUGES TIL AT HOLDE KORREKT ANTAL SVAR IMELLEM SCENER
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        SetGDProgressBar();
        //SetGEOProgressBar();
    }

    void SetGDProgressBar()
    {
        foreach (ProgressBar pBar in FindObjectsOfType<ProgressBar>())
        {
            if (pBar.QuestionType is not QuestionType.GD) continue;
            progressBarGD = pBar;

        }
        Debug.Log(progressBarGD == null ? "ProgressBar er null" : "ProgressBar fundet");
        if (progressBarGD == null) return;

        progressBarGD.UpdateProgressBar(correctGDAnswers, gDQuestionCount);
    }

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

    
    public void SpawnTheQuestion(GameObject[] array, GameObject[] finishedQuestions)
    {

        var questionIndex = Random.Range(0, array.Length);
        var answerIndex = questionIndex;
        
        
        while (finishedQuestions[questionIndex] != null)
        {
            questionIndex = Random.Range(0, array.Length);
        }
        array[questionIndex].SetActive(true);
        finishedQuestions[questionIndex] = array[questionIndex];

        correctGDAnswers = GDFinishedQuestions.Where(questionGameObject => questionGameObject != null).Count();
        gDQuestionCount = GDQuestionArray.Length;
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
        if (!GDQuestionArray[index].activeInHierarchy || !GeoQuestionArray[index].activeInHierarchy)
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
