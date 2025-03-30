using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HG_Helper : MonoBehaviour
{
    public Transform targetEmptyObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("PlayerPos").transform.position;
            targetEmptyObject = GameObject.FindGameObjectWithTag("ResetCamera").transform;
            SwitchCamera();
        }

    }

    private void SwitchCamera()
    {
        Camera.main.transform.parent = targetEmptyObject; // Die Kamera auf das leere GameObject setzen
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localRotation = Quaternion.identity;

    }
}
