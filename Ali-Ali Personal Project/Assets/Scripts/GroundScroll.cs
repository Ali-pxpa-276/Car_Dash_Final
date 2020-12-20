using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    private float speed = 5;
    private Vector3 startPos;
    private float height;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        startPos = transform.position;
        height = GetComponent<BoxCollider>().size.x /2;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGameActive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);

            if (transform.position.z < startPos.z - height)
            {
                transform.position = startPos;

            }
        }
    }
}
