using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI kills;
    [SerializeField] GunM1 gun_script;
    [SerializeField] GameObject[] zombies;
    [SerializeField] GameObject[] ammo_box;
    [SerializeField] Transform _plane;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _gun;
    [SerializeField] public int money;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammo;
    public TextMeshProUGUI moneytext;
    public int kill;
    private ZombieMovement _zombie_script;
    private bool[] isBox; 
    private bool isNearBy;
    private GunM1 _gun_script; 
    void Start()
    {
        isBox = new bool[ammo_box.Length];
        _gun_script =_gun.GetComponent<GunM1>(); 
        for( int i=0; i < zombies.Length; i++){
            _zombie_script = zombies[i].GetComponent<ZombieMovement>();

        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
        
        scoreText.text = "Bullets: " + gun_script.mag.ToString()+ "/" + gun_script.total_mags.ToString();  
        kills.text = "Kills: " + kill.ToString();
        moneytext.text = "Money: $"  + money.ToString();

        for (int i = 0; i < ammo_box.Length; i++){
           if (Vector3.Distance(player.transform.position, ammo_box[i].transform.position) < 2)
           {    isBox[i] = true;

                ammo.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)){
                _gun_script.Reload_Mag(); 
                
            }
            
            }
            else{
                isBox[i] = false;
            }  
        

        }

        for (int i = 0; i < isBox.Length; i++)
        {
            if ( isBox[i])
            {
                isNearBy = isBox[i]; 
                break;
            }
            isNearBy = isBox[i]; 

        }
        if (isNearBy != true)
        {
            ammo.gameObject.SetActive(false);

        }

        
       
    }

    


     
}
