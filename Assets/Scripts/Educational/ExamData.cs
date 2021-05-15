using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExamData
{
    [SerializeField]
    QuestionData[] questions = new QuestionData[3];

    public QuestionData[] Questions
    {
        get => questions;
    }
}
