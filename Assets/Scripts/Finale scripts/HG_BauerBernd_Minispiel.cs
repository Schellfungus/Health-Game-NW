using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class HG_BauerBernd_Minispiel : MonoBehaviour
{



    public GameObject CameraPosnnach2minispiel;

    public Texture schlusselTexture;
    public GameObject Tuer1;
    public GameObject Tuer2;



    [SerializeField]  private HG_ONSceneLaod  onSceneLoader;

    public GameObject zeitungssplitter;
    public GameObject zeitungganz;
    private void Awake()
    {

         onSceneLoader = GameObject.FindGameObjectWithTag("HG_OnSceneLoad").GetComponent<HG_ONSceneLaod>();
         GameObject bernd = GameObject.FindGameObjectWithTag("bernd");
         GameObject berndImHAus = GameObject.FindGameObjectWithTag("berndImHaus");

        if (onSceneLoader != null && onSceneLoader.gibErnte())
        {
            zeitungganz.SetActive(true);
            zeitungssplitter.SetActive(false);
            bernd.SetActive(false); 
            berndImHAus.SetActive(true);
        }
        else { bernd.SetActive(true); berndImHAus.SetActive(false); zeitungssplitter.SetActive(true); zeitungganz.SetActive(false); }



    }
    private void SwitchCamera()
    {
        Camera.main.transform.parent = CameraPosnnach2minispiel.transform; // Die Kamera auf das cameraPosition GameObject setzen
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localRotation = Quaternion.identity;

    }

    public void starteMinispiel()
    {
        
        schlieﬂeAuf();
        onSceneLoader.LadeSzene("Bernd_Reaktion");
        
    }

    public void schlieﬂeAuf()
    {
        Tuer1.GetComponent<Hg_DoorsScript>().setzeSchluessel(true, schlusselTexture);
        Tuer2.GetComponent<Hg_DoorsScript>().setzeSchluessel(true, schlusselTexture);
    }




    public bool minispiel = false;

    /////
    ///
    // Code zum minispiel im haus 

    public void zweitesMInispeil()
    {
        minispiel = true;
        onSceneLoader.LadeSzene("Zeitung_Puzzle");
     
    }











}
