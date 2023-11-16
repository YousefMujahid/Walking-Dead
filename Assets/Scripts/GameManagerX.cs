using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerX : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    [SerializeField] GunM1 gun_script;
    [SerializeField] GameObject[] zombies; 
    [SerializeField] Transform _plane; 
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
       
        scoreText.text = "Bullets: " + gun_script.mag.ToString()+ "/" + gun_script.total_mags.ToString();  
       
    }


     
}
