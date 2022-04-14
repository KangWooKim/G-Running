using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleController : MonoBehaviour
{
    
    public GameObject Dictionary;
    public GameObject Settings;
    public GameObject Records;
    public GameObject SelectMode;
    public GameObject Shop;
    public Slider BackGroundVolume;
    public Slider EffectVolume;

    public float backVol = 1f;
    public float effVol = 1f;
    

    public GameObject[] Map;
    public GameObject[] Words;
    public GameObject[] DictionaryWords;
    public GameObject[] Detail;
    public GameObject[] MyAnswer1_1;
    public GameObject[] MyAnswer1_2;
    public GameObject[] MyAnswer1_3;
    public GameObject[] MyAnswer2_1;
    public GameObject[] MyAnswer2_2;
    public GameObject[] MyAnswer2_3;
    public GameObject[] MyAnswer3_1;
    public GameObject[] MyAnswer3_2;
    public GameObject[] MyAnswer3_3;
    public GameObject[] BuySkinButton;
    public GameObject[] OnSkinButton;

    public Text Difficulty;
    public Text Page;
    public Text HighScore_Main;
    public Text HighScore_Main2;
    public Text HighScore_Main3;
    public Text Coin;

    int b = 0;
    int c = 0;
    int d = 0;

    void PlaySound(string name)
    {
        backVol = PlayerPrefs.GetFloat("effVol");
        GameObject.Find(name).GetComponent<AudioSource>().volume = effVol;
        GameObject.Find(name).GetComponent<AudioSource>().Play();
    }

    public void Start()
    {
        
        PlaySound("BGM");
        Time.timeScale = 1;
        Dictionary.SetActive(false);
        Settings.SetActive(false);
        Records.SetActive(false);
        SelectMode.SetActive(false);
        Shop.SetActive(false);
        for(int i=0; i < Map.Length; i++)
        {
            Map[i].SetActive(false);
        }
        for (int i = 0; i < Words.Length; i++)
        {
            Words[i].SetActive(false);
        }
        for (int i = 0; i < Detail.Length; i++)
        {
            Detail[i].SetActive(false);
        }
        for(int i=0; i<MyAnswer1_1.Length; i++)
        {
            MyAnswer1_1[i].SetActive(false);
            MyAnswer1_2[i].SetActive(false);
            MyAnswer1_3[i].SetActive(false);
            MyAnswer2_1[i].SetActive(false);
            MyAnswer2_2[i].SetActive(false);
            MyAnswer2_3[i].SetActive(false);
            MyAnswer3_1[i].SetActive(false);
            MyAnswer3_2[i].SetActive(false);
            MyAnswer3_3[i].SetActive(false);
        }
        MyAnswer1_1[PlayerPrefs.GetInt("1-1MyAnswer")].SetActive(true);
        MyAnswer1_2[PlayerPrefs.GetInt("1-2MyAnswer")].SetActive(true);
        MyAnswer1_3[PlayerPrefs.GetInt("1-3MyAnswer")].SetActive(true);
        MyAnswer2_1[PlayerPrefs.GetInt("2-1MyAnswer")].SetActive(true);
        MyAnswer2_2[PlayerPrefs.GetInt("2-2MyAnswer")].SetActive(true);
        MyAnswer2_3[PlayerPrefs.GetInt("2-3MyAnswer")].SetActive(true);
        MyAnswer3_1[PlayerPrefs.GetInt("3-1MyAnswer")].SetActive(true);
        MyAnswer3_2[PlayerPrefs.GetInt("3-2MyAnswer")].SetActive(true);
        MyAnswer3_3[PlayerPrefs.GetInt("3-3MyAnswer")].SetActive(true);
        HighScore_Main.text = PlayerPrefs.GetInt("HighScore-Main1")+"";
        HighScore_Main2.text = PlayerPrefs.GetInt("HighScore-Main2") + "";
        HighScore_Main3.text = PlayerPrefs.GetInt("HighScore-Main3") + "";
        Coin.text = PlayerPrefs.GetInt("Coin") + "";
        for (int i = 0; i < 3; i++)
        {
            int p = i + 1;
            if (PlayerPrefs.GetInt("BuySkin"+p) == 1)
            {
                BuySkinButton[i].SetActive(false);
            }
        }
    }

    public void Update()
    {
        SoundSlider();
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = backVol;
        for (int i = 0; i < 3; i++)
        {
            int p = i + 1;
            if (PlayerPrefs.GetInt("BuySkin" + p) == 1)
            {
                BuySkinButton[i].SetActive(false);
            }
        }
        Coin.text = PlayerPrefs.GetInt("Coin") + "";
    }
    public void SoundSlider()
    {
        backVol = BackGroundVolume.value;
        effVol = EffectVolume.value;
        PlayerPrefs.SetFloat("effVol", effVol);
        PlayerPrefs.SetFloat("backVol", backVol);
    }

    public void OnStartButtonClicked()
    {
        PlaySound("MenuSound");
        SelectMode.SetActive(true);
        Map[0].SetActive(true);
        Words[0].SetActive(true);
        
    }
    public void SelectMap()
    {

    }
    public void SelectWords()
    {

    }
    public void ButtonLeft()
    {
        b = b - 1;
        if (b < 0)
        {
            b = Map.Length - 1;
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i].SetActive(false);
            }
            Map[b].SetActive(true);
        }
        else { 
        for (int i = 0; i < Map.Length; i++)
        {
            Map[i].SetActive(false);
        }
        Map[b].SetActive(true);
        }
    }
    public void ButtonRight()
    {
        b = b + 1;
        if (b == Map.Length)
        {
            b = 0;
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i].SetActive(false);
            }
            Map[b].SetActive(true);
        }
        else
        {
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i].SetActive(false);
            }
            Map[b].SetActive(true);
        }
    }

    public void ButtonLeft1()
    {
        if (c == 0)
        {
            for (int i = 0; i < Words.Length; i++)
            {
                Words[i].SetActive(true);
            }
            Words[Words.Length - 1].SetActive(true);
            c = Words.Length - 1;
        }
        else
        {
            Words[c].SetActive(false);
            c = c - 1;
            Words[c].SetActive(true);
        }
    }
    public void ButtonRight1()
    {
        if (c == Words.Length - 1)
        {
            for (int i = 0; i < Words.Length; i++)
            {
                Words[i].SetActive(false);
            }
            Words[0].SetActive(true);
            c = 0;
        }
        else
        {
            c = c + 1;
            Words[c].SetActive(true);
        }
    }

    public void GameStartButton()
    {
        PlaySound("MenuSound");
        PlayerPrefs.SetInt("Mode", b);
        PlayerPrefs.SetInt("Speed", c);
        SceneManager.LoadScene("Loading");
           
    }

    public void OnSettingsButtonClicked()
    {
        PlaySound("MenuSound");
        Settings.SetActive(true);
    }

    public void OnDictionaryButtonClicked()
    {
        PlaySound("MenuSound");
        Dictionary.SetActive(true);
        for (int i = 0; i < DictionaryWords.Length; i++)
        {
            DictionaryWords[i].SetActive(false);
        }
        DictionaryWords[0].SetActive(true);
    }
    public void ButtonLeft2()
    {
        d = d - 1;
        if (d < 0)
        {
            d = DictionaryWords.Length - 1;
            for (int i = 0; i < DictionaryWords.Length; i++)
            {
                DictionaryWords[i].SetActive(false);
            }
            DictionaryWords[d].SetActive(true);
        }
        else
        {
            for (int i = 0; i < DictionaryWords.Length; i++)
            {
                DictionaryWords[i].SetActive(false);
            }
            DictionaryWords[d].SetActive(true);
        }
        int q = d + 1;
        Page.text = q+" ";
        if (d < 5)
        {
            Difficulty.text = "초급";
        }
        else
            Difficulty.text = "중급";
    }
    public void ButtonRight2()
    {
        d = d + 1;
        if (d == DictionaryWords.Length)
        {
            d = 0;
            for (int i = 0; i < DictionaryWords.Length; i++)
            {
                DictionaryWords[i].SetActive(false);
            }
            DictionaryWords[d].SetActive(true);
        }
        else
        {
            for (int i = 0; i < DictionaryWords.Length; i++)
            {
                DictionaryWords[i].SetActive(false);
            }
            DictionaryWords[d].SetActive(true);
        }
        int q = d + 1;
        Page.text = q+" ";
        if (d > 4)
        {
            Difficulty.text = "중급";
        }
        else
            Difficulty.text = "초급";
    }
    public void ButtonLeft3()
    {
        if (Difficulty.text == "초급")
        {
            Difficulty.text = "중급";
            d = 5;
            for (int i = 0; i < DictionaryWords.Length; i++)
            {
                DictionaryWords[i].SetActive(false);
            }
            DictionaryWords[d].SetActive(true);
            int q = d + 1;
            Page.text = q + " ";
        }
        else
        {
            Difficulty.text = "초급";
            d = 0;
            for (int i = 0; i < DictionaryWords.Length; i++)
            {
                DictionaryWords[i].SetActive(false);
            }
            DictionaryWords[d].SetActive(true);
            int q = d + 1;
            Page.text = q + " ";
        }
    }
    public void ButtonRight3()
    {
        if (Difficulty.text == "초급")
        {
            Difficulty.text = "중급";
            d = 5;
            for (int i = 0; i < DictionaryWords.Length; i++)
            {
                DictionaryWords[i].SetActive(false);
            }
            DictionaryWords[d].SetActive(true);
            int q = d + 1;
            Page.text = q + " ";
        }
        else
        {
            Difficulty.text = "초급";
            d = 0;
            for (int i = 0; i < DictionaryWords.Length; i++)
            {
                DictionaryWords[i].SetActive(false);
            }
            DictionaryWords[d].SetActive(true);
            int q = d + 1;
            Page.text = q + " ";
        }
    }

    public void onRecordsButtonClicked()
    {
        PlaySound("MenuSound");
        Records.SetActive(true);
    }

    public void OnShopButtonClicked()
    {
        PlaySound("MenuSound");
        Shop.SetActive(true);
    }

    public void OnXButtonClicked()
    {
        if (Dictionary.activeSelf == true)
            Dictionary.SetActive(false);
        else if (Settings.activeSelf == true)
            Settings.SetActive(false);
        else if (Records.activeSelf == true)
            Records.SetActive(false);
        else if (SelectMode.activeSelf == true)
            SelectMode.SetActive(false);
        else if (Shop.activeSelf == true)
            Shop.SetActive(false);
    }
    public void OnXButtonClicked1()
    {
        for (int i = 0; i < Detail.Length; i++)
        {
            Detail[i].SetActive(false);
        }
    }
    public void DetailButtonClicked(int a)
    {
        Detail[a].SetActive(true);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnExitButtonClicked()
    {
        PlaySound("MenuSound");
        Application.Quit();
    }

    public void OnSwapButtonClicked()
    {
        PlaySound("MenuSound");
        SceneManager.LoadScene("TitleSwap");
    }
    public void OnClickBuySkin1()
    {
        if (PlayerPrefs.GetInt("Coin") > 10)
        {
            int a = PlayerPrefs.GetInt("Coin") - 10;
            PlayerPrefs.SetInt("Coin", a);
        }
        else
            return;
        PlayerPrefs.SetInt("BuySkin1", 1);
        BuySkinButton[0].SetActive(false);
    }
    public void OnClickBuySkin2()
    {
        if (PlayerPrefs.GetInt("Coin") > 10)
        {
            int a = PlayerPrefs.GetInt("Coin") - 10;
            PlayerPrefs.SetInt("Coin", a);
        }
        else
            return;
        PlayerPrefs.SetInt("BuySkin2", 1);
        BuySkinButton[1].SetActive(false);
    }
    public void OnClickBuySkin3()
    {
        if (PlayerPrefs.GetInt("Coin") > 10)
        {
            int a = PlayerPrefs.GetInt("Coin") - 10;
            PlayerPrefs.SetInt("Coin", a);
        }
        else
            return;
        PlayerPrefs.SetInt("BuySkin3", 1);
        BuySkinButton[2].SetActive(false);
    }
    public void OnClickOnSkin1()
    {
        PlayerPrefs.SetInt("OnSkin1", 1);
        PlayerPrefs.SetInt("OnSkin2", 0);
        PlayerPrefs.SetInt("OnSkin3", 0);
    }
    public void OnClickOnSkin2()
    {
        PlayerPrefs.SetInt("OnSkin1", 0);
        PlayerPrefs.SetInt("OnSkin2", 1);
        PlayerPrefs.SetInt("OnSkin3", 0);
    }
    public void OnClickOnSkin3()
    {
        PlayerPrefs.SetInt("OnSkin1", 0);
        PlayerPrefs.SetInt("OnSkin2", 0);
        PlayerPrefs.SetInt("OnSkin3", 1);
    }

}
