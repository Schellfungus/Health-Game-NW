using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HG_ScreenTransitionar : MonoBehaviour
{


    public string _var;
    private HG_ONSceneLaod _Loader;
    public int spawnErkennerCheker;

    public Transform playerSpawnPos;
    public Transform CameraSpawnPos;

    

   

  
    private void Awake()
    {


        if (GameObject.FindGameObjectWithTag("HG_OnSceneLoad").GetComponent<HG_ONSceneLaod>() != null)
        {
            _Loader = GameObject.FindGameObjectWithTag("HG_OnSceneLoad").GetComponent<HG_ONSceneLaod>();

        }

        if(_Loader.getSpawnErkenner() == spawnErkennerCheker)
        {
            Debug.Log("nein"+this.name);
            
                StartCoroutine(bewegespielerundcamera());
            

        }

    }

    IEnumerator bewegespielerundcamera()
    {
        yield return new WaitForSeconds(0.4f);
        _Loader.BewegeSpielerUndCamera(playerSpawnPos.transform, CameraSpawnPos.transform);
        Debug.Log("ja" + this.name);
    }

    private void OnTriggerEnter(Collider other)
    {

             
            _Loader.LadeSzene(_var);
          
    }
    
}
