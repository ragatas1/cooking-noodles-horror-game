using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabiltKameraScript : MonoBehaviour
{
    [SerializeField] Transform spiller;
    void Update()
    {
        transform.position = new Vector3(spiller.position.x, spiller.position.y, -10);
    }
}
