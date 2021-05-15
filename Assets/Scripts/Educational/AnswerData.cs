using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;

[System.Serializable]

public class AnswerData
{
    [SerializeField]
    Sprite answer;

    [SerializeField]
    bool _isRight = false;

    public bool IsRight { get => _isRight; }

    public Sprite AnswerImage { get => answer; }
}