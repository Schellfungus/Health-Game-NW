using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HG_Alivorsteller : MonoBehaviour
{

    [SerializeField]GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject speilerSprite;
    [SerializeField] GameObject canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.SetActive(true);
            text1.GetComponent<Animator>().SetTrigger("startAnim");
            text2.GetComponent<Animator>().SetTrigger("startAnim");
            speilerSprite.GetComponent<Animator>().SetTrigger("startAnim");
            StartCoroutine(ZeigesoLange());
        }
    
       
    }

    IEnumerator ZeigesoLange()
    {
        yield return new WaitForSeconds(4f);
        canvas.SetActive(false);
    }
}
