using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   
    float _ongoing_speed = 20.0f;
    public ZombieMovement zombie_script;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _ongoing_speed * Time.deltaTime);

        Debug.Log(zombie_script.health);
    }
    
    
    void OnCollisionEnter(Collision collision)
     {
       if (collision.gameObject.tag == "Enemy"){
        zombie_script.MakeDamge(1);
          if ( zombie_script.health <= 0){
            Debug.Log("Yousef"); 
            Destroy(collision.gameObject);
          } 
               
       }
     }
}
