using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Hg_BAckpack : MonoBehaviour
{
    public GameObject briefmarkee;
    public GameObject Antragg;
    public void briefmarke(bool anAus)
    {
        briefmarkee.GetComponent<RawImage>().enabled = anAus;
    }
    public void Antrag(bool anAus)
    {
        Antragg.GetComponent<RawImage>().enabled = anAus;
    }
}
