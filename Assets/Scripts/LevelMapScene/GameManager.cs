using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Text;

public class GameManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    UnitData[] units;

    [SerializeField]
    GameObject[] Boxs;

    [SerializeField]
    Sprite[] stars;

    UnitData currentUnit;

    ExamData currentExam;

    QuestionData[] questions;

    int currentQestionIndex = 0;

    int score = 0;

    int currentUnitLesson = -1;

    bool firstExamLoaded = false;

    bool firstExamFinshed = false;

    bool unitLoaded = false;

    bool lastExamLoaded = false;

    bool video_Done = false;

    bool[] openedUnits = new bool[9] { false, false, false, false, false,false,false,false,false };

    #endregion

    public bool LastExam { get => lastExamLoaded; }

    private void Awake()
    {
        EventManager.AddUserAnsweredListiner(LoadQuestion);
        EventManager.AddAnsweredRightListiner(AddPoints);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentUnit = GetUnit();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == Scene.ExamScene.ToString())
        {          
            if (!firstExamLoaded && !lastExamLoaded)
            {
                firstExamLoaded = true;
                Instantiate<GameObject>(Resources.Load("StarHUD") as GameObject);
                currentExam = currentUnit.GetFirstExam;
                questions = currentExam.Questions;
                LoadQuestion();
            }
        }

        if(SceneManager.GetActiveScene().name == Scene.EducationalScene.ToString())
        {
            if (!unitLoaded)
            {
                unitLoaded = true;
                LoadGoals();
            }
        }

        if (SceneManager.GetActiveScene().name == Scene.ExamScene.ToString())
        {
            if(firstExamLoaded && !lastExamLoaded && firstExamFinshed && unitLoaded)
            {
                lastExamLoaded = true;
                score = 0;
                currentQestionIndex = 0;
                currentExam = currentUnit.GetLastExam;
                questions = currentExam.Questions;
                LoadQuestion();
            }
        }

    }

    UnitData GetUnit()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(
                Path.Combine(
                    Application.streamingAssetsPath,
                    "units.csv"));
            string names = input.ReadLine();
            string values = input.ReadLine();
            SetValues(values);

        }
        catch
        {
        }
        finally
        {
            if(input != null)
            {
                input.Close();
            }
        }

        int i = 0;
        while (openedUnits[i])
        {
            i++;
        }

        for(int j = 0; j < i; j++)
        {
            Boxs[j].GetComponent<Image>().sprite = Resources.Load<Sprite>("OriginalOpendChest");
        }

        return units[i];
    }

    void SetValues(string value)
    {
        string[] values = value.Split(',');
        for(int i = 0; i < 9;i++)
        {
            openedUnits[i] = Convert.ToBoolean(values[i]);
        }
    }

    void LoadQuestion()
    {
        if (currentQestionIndex >= questions.Length)
        {
            EndExam();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Question")
                .GetComponent<SpriteRenderer>().sprite = questions[currentQestionIndex].QuestionImage;
            Transform HUDTransform = GameObject.FindGameObjectWithTag("ExamHUD").transform;
            int i;
            for (i = 0; i < questions[currentQestionIndex].Answers.Length; i++)
            {
                HUDTransform.Find($"Answer{i+1}").gameObject
                    .GetComponent<AnswerButton>().SetUp(questions[currentQestionIndex].Answers[i]);
            }

            if(i <= 2)
            {
                for (; i < 4; i++)
                    HUDTransform.Find($"Answer{i+1}").gameObject.SetActive(false);
            }
            else
            {
                for(i=0; i < 4; i++)
                {
                    HUDTransform.Find($"Answer{i+1}").gameObject.SetActive(true);
                }
            }

            currentQestionIndex++;
        }
    }

    void EndExam()
    {
        GameObject.FindGameObjectWithTag("StarCarryer").GetComponent<EarnStar>().GetStar();
        Transform Hud = GameObject.FindGameObjectWithTag("ExamHUD")
            .transform;
        GameObject result = Hud.Find("Result").gameObject;
        result.SetActive(true);
        Image stars = result.transform.Find("Stars").gameObject.GetComponent<Image>();
        if (score < 5)
        {
            stars.sprite = this.stars[0];
        }else if(score < 10)
        {
            stars.sprite = this.stars[1];
        }
        else
        {
            stars.sprite = this.stars[2];
        }
        GameObject.FindGameObjectWithTag("score").GetComponent<Text>().text = score.ToString();

        if (firstExamLoaded)
        {
            firstExamFinshed = true;
        }
    }

    void LoadGoals()
    {
        GameObject.FindGameObjectWithTag("Lesson")
            .GetComponent<SpriteRenderer>().sprite = currentUnit.UnitAims;
    }

    void LoadVideo()
    {
        GameObject lesson = GameObject.FindGameObjectWithTag("Lesson");
        lesson.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LoginBackground.PNG") as Sprite;
        //lesson.transform.localScale = new Vector3(1.2f, 1.13f, 1);

        GameObject videoPlayer = Instantiate<GameObject>(Resources.Load<GameObject>("VideoPlayer"));
        videoPlayer.GetComponent<VideoPlayer>().clip = currentUnit.UnitVideo;

        Transform transform = videoPlayer.transform;

        transform.SetParent(GameObject.FindGameObjectWithTag("EducationHUD").transform, false);
    }

    public void nextButtonClicked()
    {
        GameObject video = GameObject.FindGameObjectWithTag("VideoPlayer");
        if (video != null)
        {
            Destroy(video);
        }
        Transform transform = GameObject.FindGameObjectWithTag("EducationHUD").transform;
        if (!video_Done)
        {
            video_Done = true;
            LoadVideo();
        }
        else
        {
            if (currentUnitLesson + 1 < currentUnit.GetUnitInfo.Length)
            {

                GameObject.FindGameObjectWithTag("Lesson")
                    .GetComponent<SpriteRenderer>().sprite =
                    currentUnit.GetUnitInfo[++currentUnitLesson];

                if (currentUnitLesson == 1)
                {
                    transform.Find("PreviousButton").gameObject.SetActive(true);
                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("StarCarryer").GetComponent<EarnStar>().GetStar();
                SceneManager.LoadScene(Scene.ExamScene.ToString());
            }
        }
    }

    public void previousButtonClicked()
    {
        GameObject.FindGameObjectWithTag("Lesson")
            .GetComponent<SpriteRenderer>().sprite = currentUnit.GetUnitInfo[--currentUnitLesson];
        if(currentUnitLesson == 0)
            GameObject.FindGameObjectWithTag("PreviousButton").SetActive(false);
    }

    public void EndUnit()
    {
        int i = 0;

        while (openedUnits[i])
        {
            i++;
        }

        if(i < openedUnits.Length)
            openedUnits[i] = true;

        StreamWriter output = null;
        StreamReader input = null;
        string path = Path.Combine(Application.streamingAssetsPath, "units.csv");
        try
        {
            
            input = File.OpenText(path);
            string header = input.ReadLine();
            string values = RetutnValues();
            input.Close();
            output = new StreamWriter(path);
            output.WriteLine(header);
            output.WriteLine(values);           
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            if(output != null || input != null)
            {
                output.Close();
                input.Close();
            }
        }
        AnimationControler.SetUpNextLeve(i + 1);
        SceneManager.LoadScene(Scene.OpenLevelScene.ToString());
        Destroy(gameObject);
    }

    string RetutnValues()
    {
        StringBuilder s = new StringBuilder();
        foreach(bool b in openedUnits)
        {
            s.Append(b.ToString() + ',');
        }
        return s.ToString();
    }

    void AddPoints()
    {
        score += 2;
    }
}