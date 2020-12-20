using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAudio : MonoBehaviour
{

   

    private PlayerController playerController;
    public AudioSource gameAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameAudio = GetComponent<AudioSource>();
        gameAudio.Play();

       

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
