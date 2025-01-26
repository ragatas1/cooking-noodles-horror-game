using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SpakSjekkeScript : MonoBehaviour
{
    [SerializeField] int spak;
    bool kan;
    [SerializeField] GameObject[] spaker;
    Animator animator;
    [SerializeField]int spakerIgjen;
    SpakScript spakScript;
    [SerializeField] float venteTid;
    [SerializeField] string scene;
    SpriteRenderer sprite;
    [SerializeField] Light2D lys;
    GameObject logikkFixer;
    LogikkScript logikkScript;
    AudioSource lyd;


    private void Start()
    {
        logikkFixer = GameObject.FindGameObjectWithTag("logikk");
        logikkScript = logikkFixer.GetComponent<LogikkScript>();
        animator = spaker[spak].GetComponent<Animator>();
        spakerIgjen = spaker.Length;
        sprite = spaker[spak].GetComponent<SpriteRenderer>();
        ChangeGlow();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (kan)
            {
                spak = spak + 1;
                kan = false;
                ChangeGlow();
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (kan)
            {
                spak = spak - 1;
                kan = false;
                ChangeGlow();
            }
        }
        else
        {
            kan = true;
        }
        if (spak <= -1)
        {
            spak = spaker.Length -1;
            ChangeGlow();
        }
        else if (spak >= spaker.Length)
        {
            spak = 0;
            ChangeGlow();
        }
        if (Input.GetButtonDown("gjoere"))
        {
            spakScript = spaker[spak].GetComponent<SpakScript>();
            lyd = spaker[spak].GetComponent<AudioSource>();
            if (spakScript.aktiv)
            {
                lyd.Play();
                spakerIgjen = spakerIgjen - 1;
                animator.SetTrigger("opp");
                spakScript.aktiv = false;
                StartCoroutine(Check());
            }
        }

    }
    void ChangeGlow()
    {
        animator.SetBool("glow", false);
        sprite.sortingOrder = 0;
        animator = spaker[spak].GetComponent<Animator>();
        sprite = spaker[spak].GetComponent<SpriteRenderer>();
        animator.SetBool("glow", true);
        sprite.sortingOrder = 1;
    }

    IEnumerator Check()
    {
        if (spakerIgjen <= 0)
        {
            yield return new WaitForSeconds(0.2f);
            lys.intensity = 1;
            logikkScript.lysErPaa = true;
            logikkScript.fiksetSikringen = true;
            yield return new WaitForSeconds(venteTid);
            SceneManager.LoadScene(scene);
        }
    }
}
