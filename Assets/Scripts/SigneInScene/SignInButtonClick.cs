using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignInButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleEnterButtonClick()
    {
        SceneManager.LoadScene(Scene.LevelMapScene.ToString());
        AudioManager.Play(AudioClipName.ButtonClick);
    }
}
