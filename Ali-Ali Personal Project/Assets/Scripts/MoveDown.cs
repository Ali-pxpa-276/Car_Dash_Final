using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float destroyZ = -13;
    private Rigidbody objectRB;
    private PlayerController playerController;
   
          
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        objectRB = GetComponent<Rigidbody>();
       
    }


    // Update is called once per frame
    void Update()
    {
        speed = playerController.speedVal;

        if (playerController.isGameActive)
        {
            objectRB.AddForce(Vector3.forward * -speed);
        }

        if(transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }

    }

   
}
