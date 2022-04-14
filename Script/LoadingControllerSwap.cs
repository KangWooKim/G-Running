using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingControllerSwap : MonoBehaviour
{
    float LoadingTime = 0;
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
            Tip.text = "Tip " + tipno + "\n说起韩国，就是电视剧！\n学习也要有趣啊!像G - running一样！";
        }
        else if (random == 1)
        {
            Tip.text = "Tip " + tipno + "\n대박나세요! 这是一个韩语单词，意思是成功.\n祝大家一路顺风.";
        }
        else if (random == 2)
        {
            Tip.text = "Tip " + tipno + "\n빨리빨리! 韩国人喜欢快一点的.";
        }
        else if (random == 3)
        {
            Tip.text = "Tip " + tipno + "\nHACKERS ACADEMY!\n我们正在热诚招收学生";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Loading();
        if (LoadingTime > 5)
        {
            if (PlayerPrefs.GetInt("Mode") == 0)
            {
                SceneManager.LoadScene("MainSwap");
            }
            else if (PlayerPrefs.GetInt("Mode") == 1)
            {
                SceneManager.LoadScene("Main2Swap");
            }
            else if (PlayerPrefs.GetInt("Mode") == 2)
            {
                SceneManager.LoadScene("Main3Swap");
            }
        }
    }

    void Loading()
    {
        LoadingTime = LoadingTime + Time.deltaTime;
    }
}
