using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiableC : MonoBehaviour
{
    public GameObject Panel;
    public void WhenButtonClicked()
    {
        if (Panel.activeInHierarchy == false)
        {
            Panel.SetActive(true);   
        }
        else
        {
            Panel.SetActive(false);
        }
       
        
        
    }
}
