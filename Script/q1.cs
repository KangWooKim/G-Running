using System.Collections;
using UnityEngine;

public class q1 : MonoBehaviour
{
    public GameObject[] icons;
    public void qt(int x, int z)
    {
        if (z >= 85 && z <= 105)
        {
            for(int i=0;i<4;i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 0; i < 4; i++)
                icons[i].SetActive(false);
        }
        if (z >= 174 && z <= 186)
        {
            for (int i = 4; i < 8; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 4; i < 8; i++)
                icons[i].SetActive(false);
        }

        if (z >= 276 && z <= 288)
        {
            for (int i = 8; i < 12; i++)
                icons[i].SetActive(true);
        }
        else
        {
            for (int i = 8; i < 12; i++)
                icons[i].SetActive(false);
        }
    }
   
}
