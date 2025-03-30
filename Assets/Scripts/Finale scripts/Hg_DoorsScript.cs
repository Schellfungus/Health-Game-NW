    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class Hg_DoorsScript : MonoBehaviour
{

        public Transform targetCameraPosition; // Das leere GameObject, auf das die Kamera gesetzt werden soll
        public Transform playerSpawnPoint;
        public RawImage interactionText;
        private bool isPlayerNearDoor;

    

        public bool hatSchluessel;

        private void Start()
        {

            if (interactionText != null)
            {
            
                interactionText.enabled = false;
            }

            isPlayerNearDoor= false;
        
           
        }   
        private void Update()
        {
            if (hatSchluessel == true && isPlayerNearDoor && Input.GetKeyDown(KeyCode.E))
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

        public void setzeSchluessel(bool phatSchluessel, Texture pText)
        {
            hatSchluessel = phatSchluessel;
            interactionText.texture = pText;
        }
    public void setzeSchluesselmitDialogSystem(bool phatSchluessel)
    {
        hatSchluessel = phatSchluessel;
       
    }

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNearDoor = true;
            ShowInteractionText(true);
           
        }
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
        {


            interactionText.enabled = show;
            
        }
        }

        private void SwitchCamera()
        {
            Camera.main.transform.parent = targetCameraPosition; // Die Kamera auf das cameraPosition GameObject setzen
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
