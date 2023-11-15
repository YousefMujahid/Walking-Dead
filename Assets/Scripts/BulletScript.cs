using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   
    float _ongoing_speed = 20.0f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _ongoing_speed * Time.deltaTime);

        
    }
    
    
    void OnCollisionEnter(Collision collision)
     {
       if (collision.gameObject.tag == "Enemy"){
                Debug.Log("SSSSSS");
                Destroy(collision.gameObject); 
       }
     }
}
