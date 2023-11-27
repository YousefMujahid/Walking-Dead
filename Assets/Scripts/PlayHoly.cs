using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayHoly : MonoBehaviour
{

    [SerializeField] GameObject gun;
    private GunM1 gunM1;

    private void Start()
    {
        gunM1 = gun.GetComponent<GunM1>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gunM1._Play_Sounds(10);
        }
    }


}
