using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OkButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleOkButtonClick()
    {
        AudioManager.Play(AudioClipName.ButtonClick);

        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (manager.LastExam)
        {
            manager.EndUnit();
        }
        else
            SceneManager.LoadScene(Scene.EducationalScene.ToString());
    }

}
