using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hg_Backpackaufrufer : MonoBehaviour
{
    // Start is called before the first frame update
    public void v_briefmarke(bool anAus)
    {
        GameObject.FindGameObjectWithTag("uiBackpack").GetComponent<Hg_BAckpack>().briefmarke(anAus);
    }
    public void v_Antrag(bool anAus)
    {
        GameObject.FindGameObjectWithTag("uiBackpack").GetComponent<Hg_BAckpack>().Antrag(anAus);
    }
}
