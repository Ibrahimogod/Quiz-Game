using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleStartButtonClick()
    {
        SceneManager.LoadScene(Scene.Eftta7yaScene.ToString());
        AudioManager.Play(AudioClipName.ButtonClick);
    }
}