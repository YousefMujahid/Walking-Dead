using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunM1 : MonoBehaviour
{
    [SerializeField] GameObject _bullet; 
    [SerializeField] GameObject _case; 
    float _fire_rate = .1f;
    float timer;
    float _rand;
    public int mag = 30;
    public int current_mag = 0;
    public int total_mags = 240; 
    Vector3 pos;
    Vector3 pos2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        if (timer > _fire_rate){
            timer = 0;
            Firing();
        }
        
        if (Input.GetKeyDown(KeyCode.R) && total_mags > 0 || mag == 0 && total_mags > 0){
            Debug.Log("Total mag: " + total_mags);
            Debug.Log("Current mag: " +current_mag);

            Reload();
        }

    }

    void Firing(){
            _rand = Random.Range(-.2f, .2f);
            pos = new Vector3(transform.position.x, transform.position.y+0.08f,transform.position.z);
            pos2 = new Vector3(transform.position.x+_rand, transform.position.y+_rand,transform.position.z+_rand);
        if (Input.GetButton("Fire1") && mag > 0 /*and not reloading*/){
            mag--;
            current_mag = mag;
            GameObject bul = Instantiate(_bullet, pos, transform.rotation);
            GameObject cas = Instantiate(_case, pos2, transform.rotation);
            Destroy(bul, 2);
            Destroy(cas, 2); 
        }
       
    }
    
    public void Reload(){
        if ( mag >= 0 && mag != 30 &&  total_mags>0 ){
            mag = 30;
            
            total_mags -= 30 - current_mag ;

            //another condition preventing reloading.. 
        }
    }
}
