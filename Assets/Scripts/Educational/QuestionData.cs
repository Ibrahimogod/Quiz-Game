using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]

public class QuestionData 
{
    [SerializeField]
    Sprite question;

    [SerializeField]
    AnswerData[] answers;

    public Sprite QuestionImage
    {
        get => question; 
    }

    public AnswerData[] Answers
    {
        get => answers;
    }
}