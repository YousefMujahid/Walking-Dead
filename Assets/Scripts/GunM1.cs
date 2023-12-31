using UnityEngine;

public class GunM1 : MonoBehaviour
{
    [SerializeField] GameObject _bullet; 
    [SerializeField] GameObject _case; 
    [SerializeField] public int mag = 30;
    [SerializeField] public int total_mags = 240; 
    [SerializeField] AudioSource audio; 
    [SerializeField] AudioClip shooting;
    [SerializeField] AudioClip Gun_Dry;
    [SerializeField] AudioClip shells_hitting;
    [SerializeField] AudioClip mag_in; 
    [SerializeField] AudioClip mag_out; 
    [SerializeField] AudioClip collecting_ammo;
    [SerializeField] AudioClip purchase;
    [SerializeField] AudioClip hurt;
    [SerializeField] AudioClip holy_music;
    [SerializeReference] AudioClip no_money;
    Vector3 pos;
    Vector3 pos2;
    public int current_mag = 0;
    private Animator animator;
    float _fire_rate = .1f;
    float timer;
    float _rand;
    bool isReloading = false;
   
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        if (timer > _fire_rate && !isReloading){
            timer = 0;
            Firing();
        }
        
        if (Input.GetKeyDown(KeyCode.R) && total_mags > 0 || Input.GetKeyDown(KeyCode.R) && mag == 0 && total_mags > 0){
            Reload();
            
        }
        isReloading = false;
        animator.SetBool("isReloading", Input.GetKeyDown(KeyCode.R) && total_mags > 0 || Input.GetKeyDown(KeyCode.R) && mag == 0 && total_mags > 0);

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
            Destroy(bul, 4);
            Destroy(cas, 2); 
        }
        if (Input.GetButton("Fire1") && mag > 0){
            _Play_Sounds(1);
        }
        if (Input.GetButtonDown("Fire1") && mag > 0){
            _Play_Sounds(1);
        }
       
        if ( Input.GetButton("Fire1") && mag ==0 ){
            _Play_Sounds(2);
        }       
    }
    
    public void Reload(){
        if ( mag >= 0 && mag != 30 &&  total_mags>0 ){
            isReloading = true;
            mag = 30;
            total_mags -= 30 - current_mag ;
            _Play_Sounds(4);
        }
    }

    public void Reload_Mag(){
        if (total_mags != 240){
            total_mags = 240;
            _Play_Sounds(5);
        }
    }

    public void _Play_Sounds(int case_number){

        switch(case_number){

            case 1: 
                audio.PlayOneShot(shooting); 
                break; 

            case 2: 
                audio.PlayOneShot(Gun_Dry); 
                break; 


            case 3: 
                audio.PlayOneShot(shells_hitting); 
                break; 

            case 4: 
                audio.PlayOneShot(mag_in); 
                break; 
             case 5: 
                audio.PlayOneShot(mag_out); 
                break; 

            case 6: 
                audio.PlayOneShot(collecting_ammo); 
                break; 


            case 7: 
                audio.PlayOneShot(purchase); 
                break; 

            case 8:
                audio.PlayOneShot(no_money);
                break;

            case 9:
                audio.PlayOneShot(hurt);
                break;

            case 10:
                audio.PlayOneShot(holy_music);
                break;

            default: 
                break; 


        }
    }
}
