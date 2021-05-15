using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
public class UnitData 
{
    [SerializeField]
    ExamData firstexam;

    [SerializeField]
    ExamData lastExam;

    [SerializeField]
    Sprite goals;

    [SerializeField]
    VideoClip video;

    [SerializeField]
    Sprite[] unitExplain;

    int[] stars = new int[4];

    public ExamData GetFirstExam { get => firstexam; }

    public Sprite UnitAims { get => goals; } 

    public Sprite[] GetUnitInfo { get => unitExplain; }

    public ExamData GetLastExam { get => lastExam; }

    public int[] Starts { get => stars; }

    public VideoClip UnitVideo { get => video; }
}