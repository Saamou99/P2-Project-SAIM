using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject NextLevelPanel;
    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    public void SpawnNextLevelPanel()
    {
        NextLevelPanel.SetActive(true);
    }

    public void ShutDownQuestion()
    {
        GameObject.FindGameObjectWithTag("Question").SetActive(false);
        GameObject.FindGameObjectWithTag("HintButton").SetActive(false);
        GameManager.ActivateJoyStick();

    }
    
    


   
    // Update is called once per frame
    void Update()
    {
        
    }
}
