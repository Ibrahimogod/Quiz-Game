using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandlePreviousButtonClick()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().previousButtonClicked();
        AudioManager.Play(AudioClipName.ButtonClick);
    }
}
