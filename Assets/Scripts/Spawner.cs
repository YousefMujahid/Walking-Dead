using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] zombies; 
    [SerializeField] TextMeshProUGUI zombie_info;
    [SerializeField] int number_of_zombies; 
    [SerializeField] Transform[] points;
    [SerializeField] GameObject player;
    private PlayerHealth player_health;
    private ZombieMovement _zombie_script;
    Vector3 _position;
    public int rounds = 0; 
    private int index;
    int num = 0;
    private int points_index;
    public int number_of_kills = 0;
    private int _current_number_of_zombies;
    void Start()
    {
        player_health = player.GetComponent<PlayerHealth>();
        for ( int i=0; i < zombies.Length; i++){
            _zombie_script = zombies[i].GetComponent<ZombieMovement>();

        }
        
        /*for (int i = 0; i <  number_of_zombies; i++){
            Instantiate(zombies[index], points[points_index]);
        }*/
        
    }


    void Update()
    {
        _current_number_of_zombies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        zombie_info.text = $"Zombies left: {_current_number_of_zombies} Round: {rounds}";
        
        
        

       if ( _current_number_of_zombies == 0) {
            
            rounds++;
            
            
            create_zombie();
            
       }
        
    }

    void create_zombie()
    {
        num += number_of_zombies;
        _zombie_script.health += 1;

        for (int i = 0; i <  num; i++){
            index = Random.Range(0, zombies.Length);
            points_index = Random.Range(0, points.Length);
           Instantiate(zombies[index], points[points_index].transform.position, transform.rotation);
        }

        player_health.Increase_Health();
    }
    
}
