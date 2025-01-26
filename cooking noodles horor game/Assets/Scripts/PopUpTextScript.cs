using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpTextScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] string text;
    [SerializeField] bool sendTilScene;
    [SerializeField] string sendeScene;
    bool i;
    GameObject spiller;
    PlayerMovement spillerScript;
    [SerializeField] bool funkerUtenStroem;
    GameObject logikkFixer;
    LogikkScript logikkScript;


    private void Start()
    {
        logikkFixer = GameObject.FindGameObjectWithTag("logikk");
        logikkScript = logikkFixer.GetComponent<LogikkScript>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (i && sendTilScene && Input.GetButtonDown("gjoere"))
        {
            spiller = GameObject.FindGameObjectWithTag("spiller");
            spillerScript = spiller.GetComponent<PlayerMovement>();
            spillerScript.LagrePosisjon();
            SceneManager.LoadScene(sendeScene);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spiller")
        {
            if (!logikkScript.lysErPaa && !funkerUtenStroem) { }
            else if (logikkScript.lysErPaa && funkerUtenStroem) { }
            else
            {
                txt.text = text;
                i = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spiller")
        {
            i = false;
            txt.text = "";
        }
    }
}
