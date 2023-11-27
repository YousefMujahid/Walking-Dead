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
    [SerializeField] TextMeshProUGUI no_money_txt;
    [SerializeField] GameObject spwn;
    private Spawner spawner;
    public int current_health;
    private int death_point = 0;
    private int damge_count;
    private int health_price = 1000;



    private GunM1 _gun_script;

    [SerializeField] GameObject gm;
    int track_money;
    private GameManagerX _game_manager_script;
    bool isNoMoney;


    void Start()
    {
        current_health = max_health;
        _gun_script = _gun.GetComponent<GunM1>();
        spawner = spwn.GetComponent<Spawner>();
        //_game_manager_script = gm.Get
    }
    void Update()
    {

      
        
            no_money_txt.gameObject.SetActive(isNoMoney);
        


        current_health_txt.text = $"Health: {current_health} / {this.max_health}";
        if (Input.GetKey(KeyCode.P)) 
        { 
            print_health();
        }
        heal_txt.SetActive(Vector3.Distance(this.gameObject.transform.position, center.transform.position) < 8);
        no_money_txt.gameObject.SetActive(false);
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

                if (gm.GetComponent<GameManagerX>().money < health_price)
                {
                
                no_money_txt.gameObject.SetActive(true);

                }
                if (gm.GetComponent<GameManagerX>().money >= health_price)
                {
                current_health++;
                gm.GetComponent<GameManagerX>().money -= health_price;
                
                }
               
                



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
