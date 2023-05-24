using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int RemainingQuestions = 20;
    public TextMeshProUGUI RemainingQuestionsText;
    [SerializeField] private GameObject NextLevelButton;
    [SerializeField] private GameObject _stick;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        RemainingQuestionsText.text = "Remaining Questions: " + RemainingQuestions;
    }

    public void AnswerCorrectly()
    {
        RemainingQuestions--;
        RemainingQuestionsText.text = "Remaining Questions: " + RemainingQuestions;

        if (RemainingQuestions == 0)
        {
            SpawnNextLevelButton();
        }
        
    }

    public void SpawnNextLevelButton()
    {
        NextLevelButton.SetActive(true);
    }



    public void ActivateJoyStick()
    {
        _stick.SetActive(true);
    }
    
    

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
