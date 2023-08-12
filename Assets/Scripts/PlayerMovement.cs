using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float horizontalInput;
    public bool isOnGround = true;
    private float forwardInput;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }




    void Update()
    {
       horizontalInput = Input.GetAxis("Horizontal");
       forwardInput = Input.GetAxis("Vertical");

       transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
       transform.Translate(Vector3.right *Time.deltaTime * speed * horizontalInput);

       if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
       {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
       }

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
