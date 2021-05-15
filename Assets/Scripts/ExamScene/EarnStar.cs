using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EarnStar : MonoBehaviour
{
    int gotStarNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        int stars = 3;
        for(int i = 0;i < stars; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == Scene.LevelMapScene.ToString())
        {
            Destroy(gameObject);
        }
    }

    public void GetStar()
    {
        transform.GetChild(gotStarNum++).gameObject.GetComponent<Image>().color = Color.yellow;
    }

}
