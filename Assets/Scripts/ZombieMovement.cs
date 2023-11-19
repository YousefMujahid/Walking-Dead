using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ZombieMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] public int health; 
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.forward * moveSpeed * Time.deltaTime; 
        rb.MovePosition(transform.position+move);
       animator.SetBool("isRunning", true);
       
    }

    public void MakeDamge(int num ){
        health -= num;
        if (health < 0 ){
            health = 0; 
        }
    }
    
    void OnCollisionEnter(Collision collision){
       
         if (collision.gameObject.tag == "bullet"){
            Debug.Log("Insideee");
            MakeDamge(1); 
            if ( health == 5){
                animator.SetBool("isCrawl", true); 
            }
            if ( health == 0){
                animator.SetBool("isDying", true); 
                Destroy(gameObject, 3);
            }
        }
    }
   
}
