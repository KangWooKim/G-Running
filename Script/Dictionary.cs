using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dictionary : MonoBehaviour
{
    public Text a;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=1; i<4; i++)
        {
            a.text = a.text + "1-" + i + " : " + PlayerPrefs.GetString("1-"+i) + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
