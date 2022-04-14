using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class q3 : MonoBehaviour
{
    public GameObject[] icons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void qt(int x, int z)
    {

        if (z >= 72 && z <= 90)
        {
            for (int i = 0; i < 4; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 0; i < 4; i++)
                icons[i].SetActive(false);
        }
        if (z >= 95 && z <= 113)
        {
            for (int i = 4; i < 8; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 4; i < 8; i++)
                icons[i].SetActive(false);
        }

        if (z >= 168 && z <= 186)
        {
            for (int i = 8; i < 12; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 8; i < 12; i++)
                icons[i].SetActive(false);
        }
        if (z >= 230 && z <= 248)
        {
            for (int i = 12; i < 16; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 12; i < 16; i++)
                icons[i].SetActive(false);
        }
        if (z >= 342 && z <= 360)
        {
            for (int i = 16; i < 20; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 16; i < 20; i++)
                icons[i].SetActive(false);
        }
        if (z >= 402 && z <= 420)
        {
            for (int i = 20; i < 24; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 20; i < 24; i++)
                icons[i].SetActive(false);
        }
        if (z >= 492 && z <= 510)
        {
            for (int i = 24; i < 28; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 24; i < 28; i++)
                icons[i].SetActive(false);
        }
        if (z >= 580 && z <= 598)
        {
            for (int i = 28; i < 32; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 28; i < 32; i++)
                icons[i].SetActive(false);
        }
        if (z >= 672 && z <= 690)
        {
            for (int i = 32; i < 36; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 32; i < 36; i++)
                icons[i].SetActive(false);
        }
    }

}
