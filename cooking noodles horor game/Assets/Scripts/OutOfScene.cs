using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class OutOfScene : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] Light2D lys;
    [SerializeField] float lysAvTid;
    [SerializeField] float SceneBytteTid;
    GameObject logikkFixer;
    LogikkScript logikkScript;
    [SerializeField] SpawnBobl script;
    [SerializeField] float endingTid;
    [SerializeField] string endingScene;


    private void Start()
    {
        logikkFixer = GameObject.FindGameObjectWithTag("logikk");
        logikkScript = logikkFixer.GetComponent<LogikkScript>();
        if (!logikkScript.fiksetSikringen)
        {
            StartCoroutine(GjoereGreiaSi());
        }
        else
        {
            StartCoroutine(NuddelEnding());
        }
    }


    IEnumerator NuddelEnding()
    {
        yield return new WaitForSeconds(endingTid);
        SceneManager.LoadScene(endingScene);
    }
    IEnumerator GjoereGreiaSi()
    {
        yield return new WaitForSeconds(lysAvTid);
        lys.intensity = 0.007f;
        logikkScript.lysErPaa = false;
        script.tidGreie = 0.2f;
        yield return new WaitForSeconds(SceneBytteTid);
        SceneManager.LoadScene(scene);
    }

}
