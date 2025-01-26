using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OedeleggEtterAnimasjonScript : MonoBehaviour
{
    public static OedeleggEtterAnimasjonScript denne;
    [SerializeField] AudioSource lyd;
    [SerializeField] AudioSource lyd2;
    GameObject greie;
    void Start()
    {
        greie = GameObject.FindGameObjectWithTag("greie");
        lyd2 = greie.GetComponent<AudioSource>();
        if (denne == null)
        {
            denne = this;
            lyd2.Stop();
            lyd.Play();
        }
        else
        {
            if (!lyd2.isPlaying) 
            {
                lyd2.Play();
            }
        }
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
    private void Update()
    {
        if (denne == null)
        {
            denne = this;
        }
    }
}
