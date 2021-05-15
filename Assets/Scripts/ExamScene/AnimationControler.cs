using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationControler : MonoBehaviour
{
    Timer timer;
    Animator anim;
    static int nextLeve = 2;
    bool animationdone = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        anim = GetComponent<Animator>();

        anim.enabled = false;

        timer.Duration = 2;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished && !animationdone) 
        {
            timer.Stop();
            anim.enabled = true ;
        }

        if (anim != null) 
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Destroy(anim);
                animationdone = true;
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OriginalOpendChest");
                GameObject.FindGameObjectWithTag("NextLevel").GetComponent<Text>().text = nextLeve.ToString();
                timer.Duration = 3.5f;
                timer.Run();
            } 
        }

        if(timer.Finished && animationdone)
        {
            SceneManager.LoadScene(Scene.LevelMapScene.ToString());
        }
    }

    public static void SetUpNextLeve(int num)
    {
        if (nextLeve <= num)
        {
            nextLeve = num;
        }
    }
}
