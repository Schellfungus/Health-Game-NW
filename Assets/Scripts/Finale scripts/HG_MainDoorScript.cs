using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class HG_MainDoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetEmptyObject; // Das leere GameObject, auf das die Kamera gesetzt werden soll
    public Transform playerSpawnPoint;
    public RawImage interactionText;
    public Texture First_Texture;
    private bool isPlayerNearDoor;

    private int dialogeImRathaus;

    private void Start()
    {

        if (interactionText != null)
        {
            interactionText.texture = First_Texture;
            interactionText.enabled = false;
        }

        isPlayerNearDoor = false;

     

    }
    private void Update()
    {
        
        if (dialogeImRathaus == 2 && isPlayerNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithDoor();
        }
     
    }

    private void InteractWithDoor()
    {
        SetPlayerToSpawnPoint();
        SwitchCamera();
        ShowInteractionText(false);

    }

    public Texture  neuesImage;
    private void changeShowImage()
    {
        interactionText.texture = neuesImage;   
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearDoor = true;
            ShowInteractionText(true);
        }
        dialogeImRathaus = DialogueLua.GetVariable("ImRatHausReden").asInt;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearDoor = false;
            ShowInteractionText(false);
        }
    }

    private void ShowInteractionText(bool show)
    {
        if (interactionText != null)
            interactionText.enabled = show;
    }

    private void SwitchCamera()
    {
        Camera.main.transform.parent = targetEmptyObject; // Die Kamera auf das leere GameObject setzen
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localRotation = Quaternion.identity;

    }

    private void SetPlayerToSpawnPoint()
    {
        // Setze den Spieler an die bestimmte Position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && playerSpawnPoint != null)
        {
            player.transform.position = playerSpawnPoint.position;

        }
    }


    
}
