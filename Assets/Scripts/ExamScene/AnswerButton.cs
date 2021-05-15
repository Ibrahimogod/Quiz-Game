using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    Image answerImage;

    AnswerData answerData;

    UnityEvent UserAnsweredEvent = new UnityEvent();

    UnityEvent AnsweredRight = new UnityEvent();

    private void Awake()
    {
        EventManager.AddUserAnsweredInvoker(this);
        EventManager.AddAnsweredRightInvoker(this);
        answerImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetUp(AnswerData data)
    {
        answerData = data;
        answerImage.sprite = answerData.AnswerImage;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddUserAnsweredListiner(UnityAction listiner)
    {
        UserAnsweredEvent.AddListener(listiner);
    }

    public void AddAnsweredRightListiner(UnityAction listiner)
    {
        AnsweredRight.AddListener(listiner);
    }

    public void HandleAnswerButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        if (answerData.IsRight)
        {
            Debug.Log("Gamed");
            AnsweredRight.Invoke();
        }
        else
        {
            Debug.Log("8alat");
        }
        UserAnsweredEvent.Invoke();
    }
}