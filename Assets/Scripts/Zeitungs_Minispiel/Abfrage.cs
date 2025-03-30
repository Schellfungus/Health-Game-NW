using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Simeon
public class Abfrage : MonoBehaviour
{
    public GameObject text, textFR, sanSalvador;
    public string[] moeglicheTasten;

    public Text display, puZaehler, timerB;
    public Button ausDerAsche;
    public Knopfaugen langeNase;

    public string aktuelleTaste;
    public int punkteUso;
    public float timerA;
    public bool spielenWir, gewonnen;
    bool keineRückehr;
    // Start is called before the first frame update
    //Simeon


    //variablen für start und end Animation
    public GameObject canvasEinführung;

    public GameObject anzeigeObejektPunkteZaehler;

    public GameObject anzeigeObejektZeit;
    public GameObject anzeigeObejektTask;


    public Text startCountDown;
    public bool lockk;

    public HG_BB_Minispiel_wiezenbombem animationes;

    public Text gewonnen_verlorentext;
    public GameObject buttonWeiter;
    void Awake()
    {
        spielenWir = false;
        text = GameObject.Find("DisplayUI");
        sanSalvador = GameObject.FindGameObjectWithTag("Restarter");
        langeNase = sanSalvador.GetComponent<Knopfaugen>();
        sanSalvador.SetActive(false);

        canvasEinführung.SetActive(true);
        anzeigeObejektPunkteZaehler.SetActive(false);
        anzeigeObejektZeit.SetActive(false);
        anzeigeObejektTask.SetActive(false);

        display.enabled = false;
        puZaehler.enabled   = false;
        timerB.enabled= false;
        startCountDown.enabled= false;
        gewonnen_verlorentext.enabled= false;
        buttonWeiter.SetActive(false);

        //ausDerAsche = text.GetChild("Restart");
        //knoepfchen = ausDerAsche.GetComponent<Knoepfchen>;
        //textFR = Instantiate(text);
        //text.getChild().GetComponent<TextMeshPro - text UI> () = 1;

        keineRückehr = true;

        lockk = false;
    }

    // Update is called once per frame
    void Update()
    {


        if(spielenWir == true)
        {
            timerA -= Time.deltaTime;
            //Debug.Log( timerA);
            // Ensure the timer never goes below 0
            timerA = Mathf.Max(0f, timerA);
            // = Mathf.Round(timerA * 100.0f) * 0.01f;

            timerB.text = timerA.ToString("F0");
        }

        if (timerA > 0 && spielenWir == true)
        {
            


            if (Input.GetKeyDown(aktuelleTaste))
            {
                punkteUso++;
                bisschenWuerfeln();
                animationes.Weizenpfluecken();
            }
            else for (int i = 0; i < 8; i++)
                {
                    if (Input.GetKeyDown(moeglicheTasten[i]))
                    {
                        punkteUso--;
                        if (punkteUso < 0)
                        {
                            punkteUso = 0;
                        }
                        bisschenWuerfeln();
                    }
                }
        }
        else
        {
            spielenWir = false;
        }

        if ( spielenWir == false &&  lockk == false && timerA < 1)
        {
            wennEsEndet();
            if (punkteUso > 29)
            {
                gewonnen = true;
                wennGewonnen();
            }
            else
            {
                
                wennVerloren();

            }

            lockk = true;

        }





       // if (langeNase.neustart == true)
       // {
        //    anfang();
        //    langeNase.neustart = false;
       // }

        

     
    } 

    public void bisschenWuerfeln()
    {
        aktuelleTaste = moeglicheTasten[Random.Range(0, 9)];
        display.text = aktuelleTaste;
        puZaehler.text = punkteUso.ToString();

    }

    public void anfang()
    {
        langeNase.verstecken(false);
        bisschenWuerfeln();
        timerA = 30;
    }



  

    public void wennStartKnopfGedruecktwird()
    {

        canvasEinführung.SetActive(false);
        anzeigeObejektPunkteZaehler.SetActive(true);
        anzeigeObejektZeit.SetActive(true);
        anzeigeObejektTask.SetActive(true);

        display.enabled = true;
        puZaehler.enabled = true;
        timerB.enabled = true;

        StartCoroutine(StartGameCountDown());
       
    }

    IEnumerator StartGameCountDown()
    {
        yield return new WaitForSeconds(1f);
        startCountDown.text = "3";
        startCountDown.enabled= true;
        yield return new WaitForSeconds(1f);

        startCountDown.text = "2";

        yield return new WaitForSeconds(1f);

        startCountDown.text = "1";

        yield return new WaitForSeconds(1f);
        startCountDown.text = "0";
        startCountDown.enabled = false;
        spielenWir = true;

        anfang();
    }

    public void wennEsEndet()
    {
        spielenWir = false;
        timerA = 30;


        anzeigeObejektPunkteZaehler.SetActive(false);
        anzeigeObejektZeit.SetActive(false);
        anzeigeObejektTask.SetActive(false);

        display.enabled = false;
        puZaehler.enabled = false;
        timerB.enabled = false;

    }


    public void wennGewonnen()
    {
        Debug.Log("gewonnen");
        gewonnen_verlorentext.text = "Geschafft! Ab zurück zum Bernd";
      
        buttonWeiter.SetActive(true);
        gewonnen_verlorentext.enabled = false;
        animationes.ZeigeGewonenenScreen();
    }

    public void wennVerloren()
    {
        Debug.Log("Verloren");
        gewonnen_verlorentext.text = "Ich glaube, ich muss das nochmal machen";
        gewonnen_verlorentext.enabled = true;
        langeNase.verstecken(true);
    }


    public void neuStart()
    {
        canvasEinführung.SetActive(false);
        anzeigeObejektPunkteZaehler.SetActive(true);
        anzeigeObejektZeit.SetActive(true);
        anzeigeObejektTask.SetActive(true);

        display.enabled = true;
        puZaehler.enabled = true;
        timerB.enabled = true;
        gewonnen_verlorentext.enabled = false;
        langeNase.verstecken(false);
        

        
        lockk = false;

        timerA = 30;
        StartCoroutine(StartGameCountDown());
    }

    public void gewonnenUndNeueSzeneLaden()
    {
      
        animationes.gewonnenener();
        keineRückehr = false;
    }


}
