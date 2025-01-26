using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampeneScript : MonoBehaviour
{
    [SerializeField] Light2D lys;
    GameObject logikkFixer;
    LogikkScript logikkScript;

    private void Start()
    {
        logikkFixer = GameObject.FindGameObjectWithTag("logikk");
        logikkScript = logikkFixer.GetComponent<LogikkScript>();
        sjekkLys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sjekkLys()
    {
        if (logikkScript.lysErPaa)
        {
            lys.intensity = 1;
        }
        else
        {
            lys.intensity = 0.005f;
        }
    }
}
