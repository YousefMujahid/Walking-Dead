using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] public int health; 
    [SerializeField] AudioSource zombie_audio;
    [SerializeField] AudioClip[] normal_zombie; 
    [SerializeField] AudioClip[] damge_zombie;
    Animator animator;
    NavMeshAgent zombie_navmesh;
    private GameObject _player;
    private GameObject gm;
    int half_health;
    int nor_zom_arr_index; 
    int dam_zom_arr_index; 
    bool isDying = false;
    bool isDie;
    
    void Start()
    {
        gm = GameObject.Find("GameManager").gameObject;

        half_health = health / 2;
        animator = GetComponent<Animator>();
        _player = GameObject.Find("Player").gameObject;
        zombie_navmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nor_zom_arr_index = Random.Range(0, normal_zombie.Length);
        dam_zom_arr_index = Random.Range(0, damge_zombie.Length);   
        if ( !isDying)
        {
            zombie_audio.PlayOneShot(normal_zombie[nor_zom_arr_index], .6f);
        }
         
        
        zombie_navmesh.SetDestination(_player.transform.position);
        

        animator.SetBool("isRunning", true);
        animator.SetBool("isAttack", Vector3.Distance(_player.transform.position, gameObject.transform.position) < 3f);
       
    }

    public void MakeDamge(int num ){
        health -= num;
        if (health < 0 ){
            health = 0; 
        }
    }


    
    void OnTriggerEnter(Collider other){
            
         if (other.gameObject.tag == "bullet"){
            zombie_audio.PlayOneShot(damge_zombie[dam_zom_arr_index], .6f);
            isDying = true;
            MakeDamge(1); 
            if ( health == half_health){
                zombie_navmesh.speed /= 2;
                animator.SetBool("isCrawl", true); 
            }
            if ( health <= 0)
            {
                if (!isDie)
                {
                    isDie = true;
                    zombie_navmesh.isStopped = true;
                    animator.SetBool("isDying", true);
                    gm.GetComponent<GameManagerX>().kill += 1;
                    Destroy(gameObject, 2);
                    
                     
                }
                
                
            }
         }

       
    }
    
   
}
