using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(Scene.Eftta7yaScene.ToString());
        }
    }

    public void HandleFirstButtonClick()
    {
        SceneManager.LoadScene("E3dadScene");
        AudioManager.Play(AudioClipName.ButtonClick);
    }

    public void HandleSecondButtonClick()
    {
        SceneManager.LoadScene("E4rafScene");
        AudioManager.Play(AudioClipName.ButtonClick);

    }

    public void HandleThirdButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
    }
}
