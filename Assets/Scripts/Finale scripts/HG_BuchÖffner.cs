using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using echo17.EndlessBook;

public class HG_BuchÖffner : MonoBehaviour
{
    public EndlessBook book;
    public void Start()
    {

        book.SetState(EndlessBook.StateEnum.ClosedFront);
    }
    public void oeffneTitel()
    {
        book.SetState(EndlessBook.StateEnum.ClosedFront);
    }
    public void oeffneQuellen()
    {
        book.SetState(EndlessBook.StateEnum.OpenBack);
    }
    public void oeffneWarteScreen()
    {
        book.SetState(EndlessBook.StateEnum.OpenMiddle);
    }

    
    
    private void OnMouseDown()
    {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
        GetComponent<HG_Menu>().On_Start_Click();
    }
}
}
