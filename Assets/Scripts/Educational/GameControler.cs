using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    ExamData[] exams;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public ExamData GetCurrentExamData()
    {
        return exams[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}