using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   
    float _ongoing_speed = 25.0f;
    public ZombieMovement zombie_script;
    private GameObject gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _ongoing_speed * Time.deltaTime);

    }
    
    
    void OnTriggerEnter(Collider other)

     {
       if (other.gameObject.tag == "Enemy")
        {
            gm.GetComponent<GameManagerX>().money += 10;
            
        }
     }
}
