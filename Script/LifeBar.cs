using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    
    
    public NewBehaviourScript Dog;

   
    public Image img;

    void Start()
    {
    }


    public void UpdateBar(int life)
    {
        
        if (life <= 0)
        {
            life = 0;
        }
        else
        {
            if (life > 100)
                life = 100;
            
        }
        img.fillAmount = life * 0.01f;
        

        
    }


}
