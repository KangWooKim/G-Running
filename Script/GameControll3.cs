using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControll3 : MonoBehaviour
{
    public NewBehaviourScript Dog;
    public Text scoreLabel;
    public Text CorrectRate;
    public q3 q3;

    public GameObject Menu;
    public GameObject ResultPanel;
    public GameObject a;

    public GameObject[] Star;
    public GameObject[] EmptyStar;
    public GameObject[] Star1;
    

    public LifeBar lifeBar;
    public ButtonController ButtonController;
    public Dialogue Dialogue;
    public int question = 9;
    public float backVol;
    public float effVol;
    public Slider BackGroundVolume;
    public Slider EffectVolume;

    public Text ResultScore;
    public Text ResultCorrectRate;
    public Text ResultCoin;

    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        ResultPanel.SetActive(false);
        backVol = PlayerPrefs.GetFloat("backVol");
        effVol = PlayerPrefs.GetFloat("effVol");
        BackGroundVolume.value = backVol;
        EffectVolume.value = effVol;
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);
        for (int i = 0; i < EmptyStar.Length; i++)
            EmptyStar[i].SetActive(false);
        for (int i = 0; i < Star1.Length; i++)
            Star1[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int score = CalScore();
        scoreLabel.text = score + "";
        int Rate = (int)((question - Dog.WrongRate) * 100 / question);
        CorrectRate.text = Rate + "%";
        int TalkFlag = Dog.IsTalking();

        lifeBar.UpdateBar(Dog.Life());
        q3.qt(positionx(), positionz());

        if (Dog.IsPause == true)
        {
            Menu.SetActive(true);
            backVol = BackGroundVolume.value;
            effVol = EffectVolume.value;
            PlayerPrefs.SetFloat("backVol", backVol);
            PlayerPrefs.SetFloat("effVol", effVol);
        }
        else
        {
            Menu.SetActive(false);
        }

        if (Dog.IsFinish == true)
        {
            a.SetActive(false);
            ResultPanel.SetActive(true);
            ResultScore.text = score + "";
            Rate = (int)((Dog.TotalDialogue - Dog.WrongDialogue) * 100 / Dog.TotalDialogue);
            PlayerPrefs.SetInt("Dialogue3", Rate);
            if (PlayerPrefs.GetInt("HighScore-Main3") < score)
            {
                PlayerPrefs.SetInt("HighScore-Main3", score);
            }
            ResultCorrectRate.text = Rate + "";
            ResultCoin.text = Dog.GetCoin + "";
            if (Rate == 100)
            {
                for (int i = 0; i < Star.Length; i++)
                    Star[i].SetActive(true);
                Star1[0].SetActive(true);
            }
            else if (Rate < 100 && Rate > 66)
            {
                Star1[1].SetActive(true);
                Star[0].SetActive(true);
                Star[1].SetActive(true);
                EmptyStar[2].SetActive(true);
            }
            else if (Rate < 67 && Rate > 33)
            {
                Star1[1].SetActive(true);
                Star[0].SetActive(true);
                EmptyStar[1].SetActive(true);
                EmptyStar[2].SetActive(true);
            }
            else
            {
                Star1[1].SetActive(true);
                for (int i = 0; i < EmptyStar.Length; i++)
                    EmptyStar[i].SetActive(true);
            }
        }
        else
        {
            ResultPanel.SetActive(false);
        }

        if (TalkFlag > 0)
        {
            ButtonController.DeleteButton();
            Dialogue.PanelActivate(TalkFlag);
            if (start == false)
            {
                start = true;
                Dialogue.StartTalk();
            }
        }



        if (Dog.Life() <= 0)
        {
            enabled = false;
            if (PlayerPrefs.GetInt("HighScore-Main3") < score)
            {
                PlayerPrefs.SetInt("HighScore-Main3", score);
            }
            Invoke("ReturnToTitle", 1.3f);
        }
    }
    int CalScore()
    {
        return ((int)Dog.transform.position.z + Dog.Bonus);
    }
    void ReturnToTitle()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene("Title");
        
    }
    int positionx()
    {
        return (int)Dog.transform.position.x;
    }
    int positionz()
    {
        return (int)Dog.transform.position.z;
    }
    public void ExitButtonClicked()
    {
        ReturnToTitle();
    }
    public void RetryButtonClicked()
    {
        SceneManager.LoadScene("Main3");
    }
}
