using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class LighterScript : MonoBehaviour
{
    [SerializeField] Light2D lys;
    [SerializeField] int skruPaaSjanse;
    [SerializeField] float flashTid;
    [SerializeField] int spawneSjanse;
    int spooperRng;
    [SerializeField] GameObject spooper;
    int skruPaa;
    GameObject logikkFixer;
    LogikkScript logikkScript;
    [SerializeField] AudioSource lighterFlick;
    [SerializeField] AudioSource flame;


    private void Start()
    {
        logikkFixer = GameObject.FindGameObjectWithTag("logikk");
        logikkScript = logikkFixer.GetComponent<LogikkScript>();
        lys.intensity = 1;
        spooper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("gjoere"))
        {
            skruPaa = Random.Range(0, skruPaaSjanse);
            StartCoroutine(Flash());
            lighterFlick.Play();
        }
        if (!Input.GetButton("gjoere"))
        {
            lys.intensity = 0;
            flame.Stop();
        }
    }
    IEnumerator Flash()
    {
        lys.intensity = 2;
        if (!logikkScript.lysErPaa && skruPaa != 1)
        {
            spooperRng = Random.Range(0, spawneSjanse);
            if (spooperRng == 0)
            {
                spooper.transform.position = new Vector2 (transform.position.x+0.8f, transform.position.y-0.6f);
                spooper.SetActive(true);
            }
        }
        yield return new WaitForSeconds(flashTid);
        spooper.SetActive(false);
        if (skruPaa == 1)
        {
            lys.intensity = 1;
            flame.Play();
        }
        else
        {
            lys.intensity = 0;           
        }
    }
}
