using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] zombie;
    [SerializeField] int max_health;
    [SerializeField] GameObject _gun;
    [SerializeField] GameObject center;
    [SerializeField] GameObject heal_txt;
    [SerializeField] TextMeshProUGUI current_health_txt;
    [SerializeField] GameObject spwn;
    private Spawner spawner;
    public int current_health;
    private int death_point = 0;
    private int damge_count;
    

    private GunM1 _gun_script;




    void Start()
    {
        current_health = max_health;
        _gun_script = _gun.GetComponent<GunM1>();
        spawner = spwn.GetComponent<Spawner>();
    }
    void Update()
    {
        current_health_txt.text = $"Health: {current_health} / {this.max_health}";
        if (Input.GetKey(KeyCode.P)) 
        { 
            print_health();
        }
        heal_txt.SetActive(Vector3.Distance(this.gameObject.transform.position, center.transform.position) < 8);

        if (Vector3.Distance(gameObject.transform.position, center.transform.position) < 8)
        {
            
            if (Input.GetKey(KeyCode.H)) 
            {
                Healing();
            }

        }





    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Damage();
        }
    }

    void Damage() 
    {
        if ( current_health > death_point)
        {
            current_health--;
            _gun_script._Play_Sounds(9);
        }
    }

    void Healing()
    {   
            if (current_health > death_point && current_health != max_health)
            {

                current_health++;
            }  
    }

    public void Increase_Health()
    {

        for (int i = 0; i < 100; i += 4)
        {
            if (spawner.rounds == i)
            {
                this.max_health++;
            }
        }
        
    }

    void print_health()
    {
        Debug.Log(current_health);
    }
}
