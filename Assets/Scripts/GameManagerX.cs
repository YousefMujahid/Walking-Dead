using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammo;
    [SerializeField] GunM1 gun_script;
    [SerializeField] GameObject[] zombies; 
    [SerializeField] Transform _plane; 
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] ammo_box; 
    [SerializeField] GameObject _gun; 
    private bool[] isBox; 
    private bool isNearBy;
    private GunM1 _gun_script; 
    void Start()
    {
        isBox = new bool[ammo_box.Length];
        _gun_script =_gun.GetComponent<GunM1>(); 
    
    }

    // Update is called once per frame
    void Update()
    {
        
        
        scoreText.text = "Bullets: " + gun_script.mag.ToString()+ "/" + gun_script.total_mags.ToString();  
        for(int i = 0; i < ammo_box.Length; i++){
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
