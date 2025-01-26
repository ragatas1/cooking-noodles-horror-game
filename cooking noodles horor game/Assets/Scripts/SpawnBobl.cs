using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnBobl : MonoBehaviour
{
    [SerializeField] float maxX;
    [SerializeField] float maxY;
    [SerializeField] float minX;
    [SerializeField] float minY;
    [SerializeField] float tid;
    [SerializeField] GameObject boble;
    float timer;
    public float tidGreie;
    // Start is called before the first frame update
    void Start()
    {
        timer = tid;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer -1 *Time.deltaTime;
        if (timer < 0)
        {
            tid = tid / tidGreie;
            timer = tid;
            spawn();
        }
    }
    void spawn()
    {
        Instantiate(boble, new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY)),transform.rotation);
    }
}
