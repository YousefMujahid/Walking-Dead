using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] GameObject _cam;

    [SerializeField] GameObject game_over_screen;
    public int money =0;
    [SerializeField] TextMeshProUGUI door_price_txt;
    [SerializeField] TextMeshProUGUI door_cdnt_buy;
    [SerializeField] TextMeshProUGUI ammo_cdnt_buy;
    private int _door_price = 30;
    private int mag_price = 50;
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
    private CameraMovement _cam_script;
 
    void Start()
    {
        isBox = new bool[ammo_box.Length];
        isDoor = new bool[doors.Length];
        _gun_script =_gun.GetComponent<GunM1>();
        _cam_script = _cam.GetComponent<CameraMovement>();
        for ( int i=0; i < zombies.Length; i++){
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
        GameOver();




    }

    void Get_Ammo()
    {
        for (int i = 0; i < ammo_box.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, ammo_box[i].transform.position) < 2)
            {
                isBox[i] = true;

                ammo.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F) && this.money < mag_price)
                {
                    ammo_cdnt_buy.gameObject.SetActive(true);
                    _gun_script._Play_Sounds(8);
                }
                if (Input.GetKeyDown(KeyCode.F) && this.money >= mag_price)
                {
                    _gun_script.Reload_Mag();
                    this.money = money - mag_price;

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
            ammo_cdnt_buy.gameObject.SetActive(false);

        }
    }
    void Open_Doors(int price, int money)
    {
        for (int i = 0; i < doors.Length ; i++)
        {
            //if (doors[i] != null)
            //{
                if (Vector3.Distance(player.transform.position, doors[i].transform.position) < 2)
                {
                    isDoor[i] = true;
                    door_price_txt.gameObject.SetActive(true);
                    if (this.money > 0)
                    {
                        

                        if (Input.GetKeyDown(KeyCode.F) && this.money >= price)
                        {

                            this.money = money - price;
                            _gun_script._Play_Sounds(7);
                            doors[i].transform.position = new Vector3(1000f, 1000f, 1000f);
                            

                        }
                        if (Input.GetKeyDown(KeyCode.F) && this.money < price)
                        {
                            door_cdnt_buy.gameObject.SetActive(true);
                            _gun_script._Play_Sounds(8);
                        }


                    }


                }
            //}
            else
            {
                isDoor[i] = false;
                
            }

        }
        for (int i=0; i<isDoor.Length ;i++)                 //isDoor[i] isNearByDoor
        {
                if (isDoor[i])
                {
                    isNearByDoor = isDoor[i];
                    break;
                }
                isNearByDoor = isDoor[i];

            }
        if (isNearByDoor != true)
            {
                door_price_txt.gameObject.SetActive(false);
                door_cdnt_buy.gameObject.SetActive(false);


            }


    }
    void GameOver()
    {
        if (player.GetComponent<PlayerHealth>().current_health <= 0)
        {
            game_over_screen.SetActive(true);
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<PlayerHealth>().enabled = false;
            _gun_script.enabled = false;
            _cam_script.enabled = false;
        }

    }

}

