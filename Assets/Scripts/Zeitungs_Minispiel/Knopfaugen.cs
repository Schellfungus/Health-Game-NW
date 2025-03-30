using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Simeon
public class Knopfaugen : MonoBehaviour
{
    void Awake()
    {
        //this.onClick.AddListener(clickClack);
    }
    
    // Start is called before the first frame update
    public void OnOpenButtonClick()
    {
        GameObject.FindGameObjectWithTag("BBMinispielCreater").GetComponent<Abfrage>().neuStart();
    }

    public void verstecken(bool pJN)
    {
        gameObject.SetActive(pJN);
    }

   
}
