using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject[] Panel;
    public GameObject[] Conversations;
    public NewBehaviourScript Dog;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Conversations.Length; i++)
        {
            Conversations[i].SetActive(false);
        }
        for(int i = 0; i < Panel.Length; i++)
        {
            Panel[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PanelActivate(int Talkflag)
    {
        if (Talkflag % 2 == 1)
        {
            Panel[0].SetActive(true);
            Panel[1].SetActive(false);
        }
        else
        {
            Panel[0].SetActive(false);
            Panel[1].SetActive(true);
        }
           
    }
    public void FinishTalk()
    {
        Dog.IsFinish = true;
    }
    public void Conversation1(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i + 1].SetActive(true);
    }
    public void CorrectAnswerF(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i + 1].SetActive(false);
        Conversations[i + 2].SetActive(false);
        Conversations[i + 3].SetActive(true);
        if(!PlayerPrefs.HasKey(Conversations[i].tag+"MyAnswer"))
            PlayerPrefs.SetInt(Conversations[i].tag + "MyAnswer", 0);
    }
    public void CorrectAnswerS(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i - 1].SetActive(false);
        Conversations[i + 1].SetActive(false);
        Conversations[i + 2].SetActive(true);
        if (!PlayerPrefs.HasKey(Conversations[i].tag + "MyAnswer"))
            PlayerPrefs.SetInt(Conversations[i].tag + "MyAnswer", 1);
    }
    public void CorrectAnswerT(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i -2].SetActive(false);
        Conversations[i -1].SetActive(false);
        Conversations[i + 1].SetActive(true);
        if (!PlayerPrefs.HasKey(Conversations[i].tag + "MyAnswer"))
            PlayerPrefs.SetInt(Conversations[i].tag + "MyAnswer", 2);
    }
    public void CorrectAnswer1(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i + 2].SetActive(true);
    }
    public void TryAgainF(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i + 1].SetActive(false);
        Conversations[i + 2].SetActive(false);
        Conversations[i + 4].SetActive(true);
        Dog.WrongDialogue++;
        Dog.TotalDialogue++;
        if (!PlayerPrefs.HasKey(Conversations[i].tag + "MyAnswer"))
            PlayerPrefs.SetInt(Conversations[i].tag + "MyAnswer", 0);
    }
    public void TryAgainS(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i -1].SetActive(false);
        Conversations[i + 1].SetActive(false);
        Conversations[i + 3].SetActive(true);
        Dog.WrongDialogue++;
        Dog.TotalDialogue++;
        if (!PlayerPrefs.HasKey(Conversations[i].tag + "MyAnswer"))
            PlayerPrefs.SetInt(Conversations[i].tag + "MyAnswer", 1);
    }
    public void TryAgainT(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i -2].SetActive(false);
        Conversations[i -1].SetActive(false);
        Conversations[i +2].SetActive(true);
        Dog.WrongDialogue++;
        Dog.TotalDialogue++;
        if (!PlayerPrefs.HasKey(Conversations[i].tag + "MyAnswer"))
            PlayerPrefs.SetInt(Conversations[i].tag + "MyAnswer", 2);
    }
    public void TryAgain1(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i - 4].SetActive(true);
        Conversations[i - 3].SetActive(true);
        Conversations[i - 2].SetActive(true);
    }
    public void Question(int i)
    {
        Conversations[i].SetActive(false);
        Conversations[i + 1].SetActive(true);
        Conversations[i + 2].SetActive(true);
        Conversations[i + 3].SetActive(true);
    }
    public void StartTalk()
    {
        Conversations[0].SetActive(true);
    }
    public void Flag1()
    {
        Dog.TalkFlag++;
    }
    public void Flag2()
    {
        Dog.TalkFlag--;
    }
    public void IncorrectDialogue(int i)
    {
        PlayerPrefs.SetString(Conversations[i].tag, "Incorrect");
    }
    public void CorrectDialogue(int i)
    {
        if(PlayerPrefs.GetString(Conversations[i].tag)!="Incorrect")
            PlayerPrefs.SetString(Conversations[i].tag, "Correct");
    }
}
