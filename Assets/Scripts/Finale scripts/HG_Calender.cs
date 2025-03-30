using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FirstGearGames.SmoothCameraShaker;
using PixelCrushers.DialogueSystem;

public class HG_Calender : MonoBehaviour
{
    public Texture schluesselTexture;
    public GameObject cameraWinkelZiel;
    public GameObject CameraWinkelOriginal;

    public TextMeshProUGUI interactionText, zommText;

    private bool cameraUmgestellt = false;
    private bool cameraUmgestelltlock  = false;


    bool playernear;

    bool schonGezeichent;



    public GameObject kalender;

    public Texture vorher, nacher;

    public GameObject kalenderblock;


    public ShakeData erschrokeneshakeData;


    public GameObject tuer;
    private void Awake()
    {
        interactionText.enabled = false;
        playernear= false;
        schonGezeichent = false;
        zommText.enabled = false;
       
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           
            playernear = true;
            
        } else  playernear= false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

           
            zommText.enabled = true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            zommText.enabled = false;
        }
    }
    private void SwitchCamera(GameObject parentTransform)
    {
        Camera.main.transform.parent = parentTransform.transform; // Die Kamera auf das cameraPosition GameObject setzen
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localRotation = Quaternion.identity;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && cameraUmgestellt == false && cameraUmgestelltlock == false && playernear)
        {
            SwitchCamera(cameraWinkelZiel);
            cameraUmgestellt = true;
            StartCoroutine(cooldown());
            Debug.Log("Switch");
            interactionText.enabled = true;
        } else if(Input.GetKeyDown(KeyCode.G) && cameraUmgestellt == true && cameraUmgestelltlock == true)
        {
            SwitchCamera(CameraWinkelOriginal);
            cameraUmgestelltlock = false;
            cameraUmgestellt = false;
            interactionText.enabled = false;
        }


        if(interactionText.enabled == true && !schonGezeichent && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("heyy");
            StartCoroutine(Anim());
            tuer.GetComponent<Hg_DoorsScript>().setzeSchluessel(true, schluesselTexture);
            
            schonGezeichent = true;
            interactionText.enabled = false;
        }





    }

    IEnumerator Anim()
    {
        zommText.enabled = false;
        kalenderblock.GetComponent<Animator>().SetTrigger("shake");
        yield return new WaitForSeconds(1f);
        kalender.GetComponent<MeshRenderer>().material.mainTexture = nacher;
        yield return new WaitForSeconds(1f);
        CameraShakerHandler.Shake(erschrokeneshakeData);
        yield return new WaitForSeconds(0.5f);
        GetComponent<DialogueSystemTrigger>().enabled = true;
    }
    private void FixedUpdate()
    {
        
      
    }

    IEnumerator cooldown()
    {
        Debug.Log("Warte");
        yield return new WaitForSeconds(0.5f);
       
        cameraUmgestelltlock = true;


    }
}
