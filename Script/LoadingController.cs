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
            Tip.text = "Tip " + tipno + "\n�˰� ��̳���? �߱���� ������ ����\n���� �޶����⵵ �Ѵ�ϴ�.";
        }
        else if(random == 1)
        {
            Tip.text = "Tip " + tipno + "\n������! �߱����� �����ϴ� ��������̶�� ���̿���.\n������� �����Ӱ� �귯���ٴ� ��ó�� �����е� �ູ�ϱ� �ٷ���.";
        }
        else if(random == 2)
        {
            Tip.text = "Tip " + tipno + "\n�˰� ��̳���? �߱���� ������ ����\n���� �޶����⵵ �Ѵ�ϴ�.";
        }
        else if (random == 3)
        {
            Tip.text = "Tip " + tipno + "\n������! �߱����� �����ϴ� ��������̶�� ���̿���.\n������� �����Ӱ� �귯���ٴ� ��ó�� �����е� �ູ�ϱ� �ٷ���.";
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
