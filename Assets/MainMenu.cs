using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip clip;

    private void Awake()
    {
        audio.PlayOneShot(clip);

    }
   
    public void Start_Game()
    {
        SceneManager.LoadScene("Main");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Exit_Game() 
    {
       
        UnityEditor.EditorApplication.isPlaying = false;

        
    }
}
