
using System.Collections;
using UnityEngine;

public class DragAndDropMinigame : MonoBehaviour
{
    public GameObject selectedObject;


    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("aufheben"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, -20f, worldPosition.z);

                selectedObject = null;
                Cursor.visible = true;
            }
        }

        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, -20.25f, worldPosition.z);

            
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        Debug.DrawRay(worldMousePosNear, worldMousePosFar - worldMousePosNear);
        return hit;
    }



   


    public GameObject Zeitung;
    public GameObject animationszeitung;
    public GameObject button;
    [SerializeField] private HG_ONSceneLaod loader;
    public void Awake()
    {
        Zeitung.SetActive(false);
        animationszeitung.SetActive(false);
        button.SetActive(false);
        loader = GameObject.FindGameObjectWithTag("HG_OnSceneLoad").GetComponent<HG_ONSceneLaod>();
    }


    public void gewonnen()
    {
        loader.ernte();
        StartCoroutine(winnerAnimation());
    }

    IEnumerator winnerAnimation()
    {
        animationszeitung.SetActive(true);
        Zeitung.SetActive(true);   
        yield return new WaitForSeconds(2);
        animationszeitung.SetActive(false);
        yield return new WaitForSeconds(5);
        button.SetActive(true);
    }

    public void weiter()
    {
        Debug.Log("weiter");
        loader.LadeSzene("bB_Zeitungsminispiel");
    }
}
