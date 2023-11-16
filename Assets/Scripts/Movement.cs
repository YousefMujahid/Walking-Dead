using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    float horizontal; 
    float vertical;
    float _mouse;
    float _mouseY;
    bool isOnGround = true;
    [SerializeField] float fastSpeed; 
    [SerializeField] float speed; 
    [SerializeField] float turnSpeed; 
    [SerializeField] float jumpSpeed;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical"); 
        _mouse = Input.GetAxis("Mouse X"); 
        Motion(horizontal,vertical);
        _Animation(vertical);  
    }

    
    public void Motion(float horizontal, float vertical){

        
        //Camera.main.
        var Move = Quaternion.Euler(0, transform.localEulerAngles.y, 0) * new Vector3(horizontal, -0.1f, vertical) * (vertical > 0 && Input.GetKey(KeyCode.LeftShift) ? fastSpeed : speed * Time.deltaTime);
        rb.MovePosition(transform.position+Move); 
        
        animator.SetBool("Walking", vertical > 0); 
        //transform.Rotate(0, _mouse * turnSpeed * Time.deltaTime ,0);
        if (Input.GetKeyDown(KeyCode.Space)){

            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        
        
    }

    void _Animation(float ver){
        animator.SetBool("Walking", ver > 0 || ver < 0); 
        animator.SetBool("Running", ver > 0 && Input.GetKey(KeyCode.LeftShift)); 
        
    }


}
