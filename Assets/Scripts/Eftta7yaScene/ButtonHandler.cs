using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleMenueButtonClick()
    {
        SceneManager.LoadScene(Scene.MenuScene.ToString());
        AudioManager.Play(AudioClipName.ButtonClick);
    }

    public void HandleExamButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
    }

    public void HandleStartButtonClick()
    {
        SceneManager.LoadScene(Scene.InputScene.ToString());
        AudioManager.Play(AudioClipName.ButtonClick);
    }
}