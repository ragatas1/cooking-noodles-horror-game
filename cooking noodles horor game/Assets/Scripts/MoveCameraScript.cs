using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{
    [SerializeField] bool x;
    [SerializeField] bool pos;
    [SerializeField] KameraScript script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spiller")
        {
            if (x)
            {
                if (pos && Input.GetAxisRaw("Horizontal") > 0)
                {
                    script.movement.x = Input.GetAxisRaw("Horizontal");
                }       
                else if (!pos && Input.GetAxisRaw("Horizontal") < 0)
                {
                    script.movement.x = Input.GetAxisRaw("Horizontal");
                }
                else
                {
                    script.movement.x = 0;
                }
            }
            else
            {
                if (pos && Input.GetAxisRaw("Vertical") > 0)
                {
                    script.movement.y = Input.GetAxisRaw("Vertical");
                }
                else if (!pos && Input.GetAxisRaw("Vertical") < 0)
                {
                    script.movement.y = Input.GetAxisRaw("Vertical");
                }
                else
                {
                    script.movement.y = 0;
                }
            }
        }
    }
}
