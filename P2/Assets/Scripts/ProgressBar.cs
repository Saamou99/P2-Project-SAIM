using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] QuestionType questionType = QuestionType.NOT_SET;

    public QuestionType QuestionType => questionType;

    private void Awake()
    {
        progressBar ??= GetComponent<Slider>();
    }

    public void UpdateProgressBar(float correctAnswers, float questionCount)
    {
        Debug.Log($"Correct answers: {correctAnswers} :: Question count {questionCount}");
        if (questionCount is 0)
        {
            Debug.LogError("questionCount var 0!");
            return;
        }
        progressBar.value = correctAnswers / questionCount;
    }
}


public enum QuestionType
{
    NOT_SET,
    GD,
    GEO,
}