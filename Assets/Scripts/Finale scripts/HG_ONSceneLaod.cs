

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HG_ONSceneLaod : MonoBehaviour
{
  

    private GameObject _Player;

    private Transform playerTransform;

    private int spawnErkenner = -1;

    public static HG_ONSceneLaod dieses;


     
    [SerializeField] private GameObject _loaderCanvas;

    [SerializeField]  public Image _progressBar;


    private bool animationAmAnfang;


    [SerializeField]  private bool geerntet = false;


    public Sprite[] texturen;

    public Sprite[] charakterTexturen;

    public GameObject backgroundCanvas;

    private bool ersterLoad = true;

    private bool esterminispiel = false;
    public void ernte()
    {
        geerntet = true;
    }
    public bool gibErnte()
    {
        return geerntet;
    }
    IEnumerator keineernte()
    {
        yield return new WaitForSeconds(0.4f);
        geerntet = false;
    }

   
    private void Awake()    
    {

        animationAmAnfang = true;

        if (dieses == null)
        {
            dieses = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        _loaderCanvas.SetActive(false);
    }



    public async void LadeScene(string sceneName)
    {
        
        _progressBar.fillAmount = 0;


       var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

        if(sceneName == "Health" && animationAmAnfang)
        {
            animationAmAnfang = false;

        }

        while (_progressBar.fillAmount < 0.9f && scene.progress < 0.9)
         {
            await Task.Delay(500);


            _progressBar.fillAmount = _progressBar.fillAmount + 0.2f;
          
         }

        scene.allowSceneActivation = true;



        await Task.Delay(1000);

        _loaderCanvas.SetActive(false);
        andereLoadScreen();


        _Player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = _Player.GetComponent<Transform>();


      
    }

 
    
        
    




    public void LadeSzene(string SzenenName)
    {



        if(SzenenName == "aA")
        {
            spawnErkenner = 3;
            playerTransform.rotation  = new Quaternion(Quaternion.identity.x,Quaternion.identity.y,180,Quaternion.identity.w);
            LadeScene("newone"); 
        }
        if (SzenenName == "bB")
        {
            spawnErkenner = 4;
            playerTransform.rotation = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, 180, Quaternion.identity.w);
            LadeScene("Bürgermeister");
        }
        if (SzenenName == "bBmini")
        {
            spawnErkenner = 8;
            playerTransform.rotation = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, 180, Quaternion.identity.w);
            StartCoroutine(aendereNummer(4));
            LadeScene("Bürgermeister");
        }
        if (SzenenName == "bB_Zeitungsminispiel")
        {
            spawnErkenner = 10;
            StartCoroutine(aendereNummer(4));
            LadeScene("Bürgermeister");
           
        }

        if (SzenenName == "rathaus")
        {
            spawnErkenner = 1;
            
            LadeScene("BauerBernd");
        }
        if(SzenenName == "main")
        {
            if (_Player != null)
            {
                playerTransform.rotation = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, 0, Quaternion.identity.w);
                LadeScene("Health");
            }
            else LadeScene("Health");
            
            
        }
        if(SzenenName == "inRathaus")
        {
            spawnErkenner = 2;
            LadeScene("Im_Rathaus");
        }
        if(SzenenName == "Zeitung_Puzzle")
        {
            LadeScene("Zeitung_Puzzle");
            geerntet = true;
        }
        if (SzenenName == "Bernd_Reaktion")
        {
           
            LadeScene("Bernd_Reaktion");
            
        }
    }


     IEnumerator aendereNummer(int num)
    {
        yield return new WaitForSeconds(5f);
        spawnErkenner = num;
        yield return new WaitForSeconds(10f);
        geerntet= false;
    }


    public void BewegeSpielerUndCamera(Transform playerSpawn,Transform CameraSpawn)
    {
        _Player = GameObject.FindGameObjectWithTag("Player");

        if (spawnErkenner == 4 && geerntet)
        {
            _Player.transform.position = new Vector3(-37.866f, 1.406f, 19.446f);
            StartCoroutine(keineernte());


        }
        else
        {
            

            _Player.transform.position = playerSpawn.position;
            Camera.main.transform.parent = CameraSpawn;
            Camera.main.transform.localPosition = Vector3.zero;
            Camera.main.transform.localRotation = Quaternion.identity;
        }
        
    }



    public int getSpawnErkenner()
    {
        return spawnErkenner;   
    }

    // 0 = main
    // 1 = ausenBurgermeister
    // 2 = ImRathaus
    // 3 = AA
    // 4 = BB
    // 5 = Puzzle Minigame




 
    public void andereLoadScreen()
   {
        int i = (int)Random.Range(0, 4);
        backgroundCanvas.GetComponent<Image>().sprite = texturen[i];
        int e = (int)Random.Range(0, 4  );
        _progressBar.GetComponent<Image>().sprite = charakterTexturen[e];   
    }



    public void ersterloade(GameObject FirstWinkel, GameObject FirstSpawnPoint)
    {
        if (ersterLoad == true)
        {


            ersterLoad = false;
            BewegeSpielerUndCamera(FirstSpawnPoint.transform, FirstWinkel.transform);
        }
    }



}
