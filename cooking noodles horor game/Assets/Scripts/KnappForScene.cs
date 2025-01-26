using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnappForScene : MonoBehaviour
{
    [SerializeField] float venteTid;
    [SerializeField] string scene;
    GameObject logikkFixer;
    bool kan;

    private void Start()
    {
        logikkFixer = GameObject.FindGameObjectWithTag("logikk");       
        if (logikkFixer != null)
        {
            Destroy(logikkFixer);
        }
        StartCoroutine(greie());
    }

    // Update is called once per frame
    void Update()
    {
        if (kan && Input.GetButtonDown("gjoere"))
        {
            SceneManager.LoadScene(scene);
        }
    }
    IEnumerator greie()
    {
        yield return new WaitForSeconds(venteTid);
        kan = true;
    }
}
