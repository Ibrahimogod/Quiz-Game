using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<AnswerButton> UserAnsweredInvokers = new List<AnswerButton>();
    static List<UnityAction> UserAnsweredListiners = new List<UnityAction>();

    static List<AnswerButton> AnsweredRightInvokers = new List<AnswerButton>();
    static List<UnityAction> AnsweredRighListiners = new List<UnityAction>();


    public static void AddUserAnsweredInvoker(AnswerButton invoker)
    {
        UserAnsweredInvokers.Add(invoker);
        foreach(UnityAction listiner in UserAnsweredListiners)
        {
            invoker.AddUserAnsweredListiner(listiner);
        }
    }

    public static void AddUserAnsweredListiner(UnityAction listiner)
    {
        UserAnsweredListiners.Add(listiner);
        foreach(AnswerButton invoker in UserAnsweredInvokers)
        {
            invoker.AddUserAnsweredListiner(listiner);
        }
    }

    public static void AddAnsweredRightInvoker(AnswerButton invoker)
    {
        AnsweredRightInvokers.Add(invoker);
        foreach (UnityAction listiner in AnsweredRighListiners)
        {
            invoker.AddAnsweredRightListiner(listiner);
        }
    }

    public static void AddAnsweredRightListiner(UnityAction listiner)
    {
        AnsweredRighListiners.Add(listiner);
        foreach (AnswerButton invoker in AnsweredRightInvokers)
        {
            invoker.AddAnsweredRightListiner(listiner);
        }
    }
}
