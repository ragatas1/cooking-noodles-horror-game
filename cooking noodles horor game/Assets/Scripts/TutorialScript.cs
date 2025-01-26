using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    GameObject logikkFixer;
    LogikkScript logikkScript;
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] string text;
    private void Start()
    {
        logikkFixer = GameObject.FindGameObjectWithTag("logikk");
        logikkScript = logikkFixer.GetComponent<LogikkScript>();
        if (!logikkScript.lysErPaa)
        {
            txt.text = text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("gjoere"))
        {
            txt.text = "";
        }
    }
}
