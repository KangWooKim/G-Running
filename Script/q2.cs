using System.Collections;
using UnityEngine;

public class q2 : MonoBehaviour
{
    public GameObject[] icons;
    public void qt(int x, int z)
    {
       
        if (z >= 60 && z <= 78)
        {
            for (int i = 0; i < 4; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 0; i < 4; i++)
                icons[i].SetActive(false);
        }
        if (z >= 148 && z <= 178)
        {
            for (int i = 4; i < 8; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 4; i < 8; i++)
                icons[i].SetActive(false);
        }

        if (z >= 220 && z <= 240)
        {
            for (int i = 8; i < 12; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 8; i < 12; i++)
                icons[i].SetActive(false);
        }
        if (z >= 312 && z <= 330)
        {
            for (int i = 12; i < 16; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 12; i < 16; i++)
                icons[i].SetActive(false);
        }
        if (z >= 402 && z <= 420)
        {
            for (int i = 16; i < 20; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 16; i < 20; i++)
                icons[i].SetActive(false);
        }
        if (z >= 492 && z <= 510)
        {
            for (int i = 20; i < 24; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 20; i < 24; i++)
                icons[i].SetActive(false);
        }
        if (z >= 582 && z <= 600)
        {
            for (int i = 24; i < 28; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 24; i < 28; i++)
                icons[i].SetActive(false);
        }
        if (z >= 672 && z <= 690)
        {
            for (int i = 28; i < 32; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 28; i < 32; i++)
                icons[i].SetActive(false);
        }
        if (z >= 738 && z <= 756)
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
