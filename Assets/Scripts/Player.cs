using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform=null;
    [SerializeField] private bool isBlue;
    bool isJumpKeyPressedBlue;
    bool isJumpKeyPressedRed;
    private float horizontalInputBlue;
    private float horizontalInputRed;
    private Rigidbody rigidbodyComponent;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlue)
        {
            if (Input.GetKeyDown(KeyCode.W))
                isJumpKeyPressedBlue = true;
            horizontalInputBlue = Input.GetAxis("HorizontalBlue");
        }
        if (!isBlue)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                isJumpKeyPressedRed = true;
            horizontalInputRed = Input.GetAxis("HorizontalRed");
        }
        
       
    }

    void FixedUpdate()
    {
        
       

        
        if (isBlue)
        {
            rigidbodyComponent.velocity = new Vector3(horizontalInputBlue * 5.5f, rigidbodyComponent.velocity.y, 0);
            if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length <= 1)
            {
                return;
            }

            if (isJumpKeyPressedBlue)
            {
                rigidbodyComponent.AddForce(Vector3.up * 6.5f, ForceMode.VelocityChange);
                isJumpKeyPressedBlue = false;
            }
        }
        if (!isBlue)
        {
            rigidbodyComponent.velocity = new Vector3(horizontalInputRed * 5.5f, rigidbodyComponent.velocity.y, 0);
            
            if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length <= 1)
            {
                return;
            }

            if (isJumpKeyPressedRed)
            {
                rigidbodyComponent.AddForce(Vector3.up * 6.5f, ForceMode.VelocityChange);
                isJumpKeyPressedRed = false;
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {    
    }

    private void OnCollisionExit(Collision collision)
    {
    }

}
