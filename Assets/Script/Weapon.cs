using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Animations.Rigging;

public class Weapon : MonoBehaviour
{

    public GameObject[] _Weapons;
    [SerializeField] int _Maximum_ammo;
    [SerializeField] int _Mag;
    [SerializeField] int _Amintion;
    [SerializeField] float firerate;
    [SerializeField] TextMeshProUGUI text;
    public int damge;
    public int range;
    private int  _Current_bullet;
    public GameObject _Bullet;
    public AudioClip[] audioClips;
    public ParticleSystem ammo_seaprt;
    public int time_to_reload;
    private bool  isreloading;
    bool is_gun_uphrade;
    AudioSource audioSource;
    private float nexttimefire;
    [SerializeField] Camera _camera;
    [SerializeField] Rig rig;
    RaycastHit raycastHit;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _Amintion = _Maximum_ammo;
        text.text = $"{_Amintion } / {_Mag}";
    }
    void Upgrade_gun()
    {

    }
    IEnumerator reloading()
    {
        isreloading = true;
        ammo_seaprt.Stop();
        if (_Amintion == 0  && _Mag > 0 || _Amintion < _Maximum_ammo && _Mag > 0)
        {
            rig.weight = 0;
            _Current_bullet = _Maximum_ammo - _Amintion;
            _Mag -= _Current_bullet;
            _Amintion += _Current_bullet;
        }
        yield return new WaitForSeconds(time_to_reload);
        isreloading = false;
        rig.weight = 1;
        text.text = $"{_Amintion } / {_Mag}";
    }
    void _fire()
    {
        if (Input.GetKey(KeyCode.Mouse0) && nexttimefire > firerate && _Amintion != 0)
        {
            if(!ammo_seaprt.isPlaying)
            ammo_seaprt.Play();
            if (_Amintion > 0)
            {
                _Amintion--;
                text.text = $"{_Amintion } / {_Mag}";
            }
            if(Physics.Raycast(_camera.transform.position, _camera.transform.forward,out raycastHit, range))
            {
                if(raycastHit.transform.gameObject.tag == "zm")
                {
                    Destroy(raycastHit.transform.gameObject);
                }
            }
            nexttimefire = 0;
            audioSource.PlayOneShot(is_gun_uphrade ? audioClips[1] : audioClips[0], 0.7f);
        }
        if(!Input.GetKey(KeyCode.Mouse0) && nexttimefire > firerate)
        {
            ammo_seaprt.Stop();
        }
    }
    void Update()
    {
        nexttimefire += Time.deltaTime;
        if (isreloading)
            return;
        if (Input.GetKeyDown(KeyCode.R) || _Amintion <= 0)
        {
            StartCoroutine(reloading());
            return;
        }
        _fire();
    }
}
