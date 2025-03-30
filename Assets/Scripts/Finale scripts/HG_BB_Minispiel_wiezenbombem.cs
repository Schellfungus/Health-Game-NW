using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HG_BB_Minispiel_wiezenbombem : MonoBehaviour
{
    public Color hit1;
    public Color hit2;  
    public Color hit3;

    public SpriteRenderer[] weizens = new SpriteRenderer[30]; 
    private GameObject[] weizensBAckup = new GameObject[30];

    private int zaehler;


    public GameObject ui1;
    public GameObject ui2;
    private void Start()
    {
        ui1.SetActive(false);
        ui2.SetActive(false);

        for(int i = 0;i < weizens.Length; i++)
        {
            weizensBAckup[i] = weizens[i].gameObject;
        }
     


        zaehler = 0;
    }
    public void Weizenpfluecken()
    {
     
    
        SpriteRenderer weizendasGeerntetwird;

        weizendasGeerntetwird = weizens[zaehler];

        
         
        
        if(weizendasGeerntetwird.color == hit1)
        {
            weizendasGeerntetwird.color = hit2;

        }else if (weizendasGeerntetwird.color == hit2)
        {
            weizendasGeerntetwird.color = hit3;
        }else if(weizendasGeerntetwird.color != hit3 && weizendasGeerntetwird.color != hit2)
        {
            weizendasGeerntetwird.color = hit1;

        }else if(weizendasGeerntetwird.color == hit3)
        {
            Destroy(weizens[zaehler]);
            zaehler++;
        }
    
    
    }

        

    public void ZeigeGewonenenScreen()
    {
        ui1.SetActive(true); ui2.SetActive(true);
    }
    public void gewonnenener()
    {
        
       
       
        GameObject.FindGameObjectWithTag("HG_OnSceneLoad").GetComponent<HG_ONSceneLaod>().LadeSzene("bBmini");
    }

    IEnumerator warteKurz()
    {
        yield return new WaitForSeconds(3f);
    }




}



