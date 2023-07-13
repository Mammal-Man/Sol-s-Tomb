using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float inputHoriz;
    public bool isOnGround;
    private Rigidbody2D playerRb;
    public float speed = 2.5f;
    public float gravMod = 1;
    public float playerPosX;
    public float playerPosY;
    public GameObject player;
    private float xBound = 12;
    private float yBound = 5;
    public float jumpForce = 6.45f;
    public ParticleSystem walkingParticle;
    public bool isWalking;
    public AudioClip walksound;
    private AudioSource playerSFX;
    private Animator likeToMoveIt;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        likeToMoveIt = GetComponent<Animator>();
        Physics.gravity *= gravMod;
        playerSFX = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        inputHoriz = Input.GetAxis("Horizontal");
        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;


        if (playerRb.transform.position.x < -xBound)
        {
            playerRb.transform.position = new Vector3(xBound, playerPosY);
        }

        if (playerRb.transform.position.x > xBound)
        {
            playerRb.transform.position = new Vector3(-xBound, playerPosY);
        }

        if (playerRb.transform.position.y < -yBound)
        {
            playerRb.transform.position = new Vector3(playerPosX, yBound);
        }

        if (playerRb.transform.position.y > yBound)
        {
            playerRb.transform.position = new Vector3(playerPosX, -yBound);
        }

        if (Input.GetKeyDown(KeyCode.W) && isOnGround == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if(inputHoriz == 0)
        {
            isWalking = false;
            walkingParticle.Pause();
            walkingParticle.gameObject.SetActive(false);
            likeToMoveIt.SetBool("isWalking", false);
        }
        else if (isOnGround == true)
        {
            isWalking = true;
            walkingParticle.gameObject.SetActive(true);
            walkingParticle.Play();
            playerSFX.PlayOneShot(walksound, 0.5f);
            likeToMoveIt.SetTrigger("isWalking");
        }

        if (inputHoriz < 0)
        {
            likeToMoveIt.SetBool("facingLeft", true);
        }
        else if (inputHoriz > 0)
        {
            likeToMoveIt.SetBool("facingLeft", false);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * inputHoriz);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}
