using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehavior : MonoBehaviour
{
    
    public QuestionBehavior QuestionBehavior;

// Start is called before the first frame update
    void Start()
    {
        QuestionBehavior = GameObject.Find("GameManager").GetComponent<QuestionBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (tag)
        {
            case "GDCollider":
                if (col.CompareTag("Player"))
                {
                    QuestionBehavior.SpawnGDQuestion();
                    if (GameObject.FindGameObjectWithTag("Question").activeInHierarchy)
                    {
                        GameObject.FindGameObjectWithTag("Stick").SetActive(false);
                    }
                    
                }
                break;
            case "GeoCollider":
                if (col.CompareTag("Player"))
                {
                    QuestionBehavior.SpawnGeoQuestion();
                    if (GameObject.FindGameObjectWithTag("Question").activeInHierarchy)
                    {
                        GameObject.FindGameObjectWithTag("Stick").SetActive(false);
                    }
                    
                }
                break;
            
            
        }
        
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
