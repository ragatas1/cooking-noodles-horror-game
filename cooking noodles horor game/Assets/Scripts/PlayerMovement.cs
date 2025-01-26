using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Rigidbody2D rb;
    Vector2 movement;
    GameObject kamera;
    GameObject logikkFixer;
    LogikkScript logikkScript;


    private void Start()
    {
        logikkFixer = GameObject.FindGameObjectWithTag("logikk");
        logikkScript = logikkFixer.GetComponent<LogikkScript>();
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        transform.position = logikkScript.spillerPosisjon;
        transform.rotation = logikkScript.spillerRotasjon;
        kamera.transform.position = logikkScript.kameraPosisjon;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }      
    public void LagrePosisjon()
    {
        logikkScript.spillerPosisjon = transform.position;
        logikkScript.spillerRotasjon = transform.rotation;
        logikkScript.kameraPosisjon = kamera.transform.position;
    }
}
