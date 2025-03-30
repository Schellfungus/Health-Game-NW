using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hg_FirstAnim : MonoBehaviour
{
    [SerializeField] Animator derAnim;
    [SerializeField] GameObject brief;
    void Awake()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        brief.SetActive(false);
        derAnim.SetTrigger("mach anim");
    }

}
