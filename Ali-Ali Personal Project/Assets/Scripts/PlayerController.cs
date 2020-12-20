using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public ParticleSystem coinParticle;
    public ParticleSystem crashParticle;
    public float speedVal = 7;
    public bool isGameActive;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public AudioClip coinCollected;
    public AudioClip crashSound;


   


    private int score;
    private float speed = 15.0f;
    private float xRange = 22.4f;
    private float zRange = 12f;
    private float zRange2 = -6f;
    private AudioSource carAudio;
    private CamAudio camAudio;
    private string url = "https://github.com/Ali-pxpa-276/Car_Dash_Final";


    private Rigidbody PlayerRb;
    // Start is called before the first frame update
    void Start()
    {
       carAudio =  GetComponent<AudioSource>();
        camAudio = GameObject.Find("Main Camera").GetComponent<CamAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            movePlayer();
        }
       

        limitPlayerPosition();


    }

    public void startGame()
    {
        scoreText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        PlayerRb = GetComponent<Rigidbody>();
        updateScore(0);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score: " + score;
    }

    public void gameOver()
    {
        camAudio.gameAudio.Stop();
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
       
    }
     

    // allows player to move through arrow keys
    void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        float verticalInput = Input.GetAxis("Vertical");
         transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

      
    }


    // sets boundaries so player doesnt not  fall off the map
    void limitPlayerPosition()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);

        }

        if (transform.position.z < zRange2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange2);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Traffic"))
        {
           // Debug.Log("player collided with traffic");
            Instantiate(crashParticle, gameObject.transform.position, crashParticle.transform.rotation);
            carAudio.PlayOneShot(crashSound, 0.25f);
            gameOver();

        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {

            Destroy(other.gameObject);
            carAudio.PlayOneShot(coinCollected, 1.0f);
            Instantiate(coinParticle, other.gameObject.transform.position, coinParticle.transform.rotation);
            speedVal +=2;
            updateScore(2);


        }
    }

    public void LoadUrl()
    {
        Application.OpenURL(url);
    }


}

