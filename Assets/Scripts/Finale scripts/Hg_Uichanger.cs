using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.GridLayoutGroup;

public class Hg_Uichanger : MonoBehaviour
{
    public static Texture vorher;
    public Texture nacher;

    private void OnTriggerEnter(Collider other)
    {
        vorher = GameObject.FindGameObjectWithTag("Uiselector").GetComponent<RawImage>().texture;
        GameObject.FindGameObjectWithTag("Uiselector").GetComponent<RawImage>().texture = nacher;
    }
    private void OnTriggerExit(Collider other)
    {
        if(GameObject.FindGameObjectWithTag("Uiselector").activeSelf  == true)
        {
            GameObject.FindGameObjectWithTag("Uiselector").GetComponent<RawImage>().texture = vorher;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Uiselector").SetActive(true);
            GameObject.FindGameObjectWithTag("Uiselector").GetComponent<RawImage>().texture = vorher;
            GameObject.FindGameObjectWithTag("Uiselector").SetActive(false);
        }
        
    }

}
