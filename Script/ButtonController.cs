using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject[] icons;
    public void DeleteButton()
    {
        for (int i = 0; i < icons.Length; i++)
            icons[i].SetActive(false);
    }
}
