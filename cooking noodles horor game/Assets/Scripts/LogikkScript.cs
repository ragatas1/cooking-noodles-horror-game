using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LogikkScript : MonoBehaviour
{
    public Vector2 spillerPosisjon;
    public quaternion spillerRotasjon;
    public Vector3 kameraPosisjon;
    public static LogikkScript instance;
    public bool lysErPaa;
    public bool fiksetSikringen;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
