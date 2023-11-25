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
    [SerializeField] GameObject[] doors;
    [SerializeField] Transform _plane;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _gun;

    [SerializeField] GameObject game_over_screen;
    public int money =0;
    [SerializeField] TextMeshProUGUI door_price_txt;
    [SerializeField] TextMeshProUGUI door_cdnt_buy;
    private int _door_price = 3000;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammo;
    [SerializeField] TextMeshProUGUI moneytext;
    public int kill = 0;
    private ZombieMovement _zombie_script;
    private bool[] isBox;
    private bool[] isDoor;
    private bool isNearBy;
    private bool isNearByDoor;
    private GunM1 _gun_script; 
    void Start()
    {
        isBox = new bool[ammo_box.Length];
        isDoor = new bool[doors.Length];
        _gun_script =_gun.GetComponent<GunM1>(); 
        for( int i=0; i < zombies.Length; i++){
            _zombie_script = zombies[i].GetComponent<ZombieMovement>();

        }
    
    }

    // Update is called once per frame
    void Update()
    {

        Get_Ammo();
        Open_Doors(_door_price, money);
        scoreText.text = "Bullets: " + gun_script.mag.ToString()+ "/" + gun_script.total_mags.ToString();  
        kills.text = "Kills: " + kill.ToString();
        moneytext.text = "Money: $" + money.ToString();

        if (player.GetComponent<Movement>().player_health <= 0) 
        {
            game_over_screen.SetActive(true);
            //play sound
            //disable the script
            //restart if wish

        }


    }

    void Get_Ammo()
    {
        for (int i = 0; i < ammo_box.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, ammo_box[i].transform.position) < 2)
            {
                isBox[i] = true;

                ammo.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _gun_script.Reload_Mag();

                }

            }
            else
            {
                isBox[i] = false;
            }


        }

        for (int i = 0; i < isBox.Length; i++)
        {
            if (isBox[i])
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
    void Open_Doors(int price, int money)
    {
        for (int i = 0; i < doors.Length ; i++)
        {
            if (Vector3.Distance(player.transform.position, doors[i].transform.position) < 2)
            {
                isDoor[i] = true;
                door_price_txt.gameObject.SetActive(true);
                if (money > 0)
                {
                    if (Input.GetKeyDown(KeyCode.F) && money < price)
                    {
                        door_cdnt_buy.gameObject.SetActive(true);
                        _gun_script._Play_Sounds(8);
                    }

                    if (Input.GetKeyDown(KeyCode.F) && money >= price)            
                    {

                        this.money = money- price;
                        _gun_script._Play_Sounds(7);

                    }

                   
                }


            }
            else 
            {
                isDoor[i] = false;
            }
            

            for (int j=0; j<isDoor.Length ;j++)
            {
                if (isDoor[j])
                {
                    isNearByDoor = isDoor[j];
                    break;
                }
                isNearByDoor = isDoor[j];

            }
            if (isNearByDoor != true)
            {
                door_price_txt.gameObject.SetActive(false);
                door_cdnt_buy.gameObject.SetActive(false);


            }



        }

        

        
    }






}
