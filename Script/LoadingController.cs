using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    float LoadingTime1 = 0;
    public int random;
    public Text Tip;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        random = Random.Range(0, 4);
        int tipno = random + 1;
        if (random == 0)
        {
            Tip.text = "Tip " + tipno + "\n알고 계셨나요? 중국어는 성조에 따라\n뜻이 달라지기도 한답니다.";
        }
        else if(random == 1)
        {
            Tip.text = "Tip " + tipno + "\n六六大順! 중국인이 좋아하는 육육대순이라는 말이에요.\n모든일이 순조롭게 흘러간다는 뜻처럼 여러분도 행복하길 바래요.";
        }
        else if(random == 2)
        {
            Tip.text = "Tip " + tipno + "\n알고 계셨나요? 중국어는 성조에 따라\n뜻이 달라지기도 한답니다.";
        }
        else if (random == 3)
        {
            Tip.text = "Tip " + tipno + "\n六六大順! 중국인이 좋아하는 육육대순이라는 말이에요.\n모든일이 순조롭게 흘러간다는 뜻처럼 여러분도 행복하길 바래요.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        LoadingTime1 = LoadingTime1 + Time.deltaTime;
        if (LoadingTime1 > 5)
        {
            if (PlayerPrefs.GetInt("Mode") == 0)
            {
                SceneManager.LoadScene("Main");
            }
            else if (PlayerPrefs.GetInt("Mode") == 1)
            {
                SceneManager.LoadScene("Main2");
            }
            else if (PlayerPrefs.GetInt("Mode") == 2)
            {
                SceneManager.LoadScene("Main3");
            }
        }
    }

    void Loading1()
    {
        LoadingTime1=LoadingTime1 + Time.deltaTime;
    }
}
