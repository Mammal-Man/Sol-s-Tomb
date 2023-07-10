using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float inputHoriz;
    public bool isOnGround;
    private Rigidbody2D playerRb;
    public float speed;
    public float gravMod;
    public float playerPosX;
    public float playerPosY;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravMod;
    }

    // Update is called once per frame
    void Update()
    {
        inputHoriz = Input.GetAxis("Horizontal");
        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;

        if (playerRb.transform.position.x < -12)
        {
            Instantiate(player, new Vector3(12, playerPosY), player.transform.rotation);
        }
        if (playerRb.transform.position.x > 12)
        {
            Instantiate(player, new Vector3(-12, playerPosY), player.transform.rotation);
        }
        if (playerRb.transform.position.y < -5)
        {
            Instantiate(player, new Vector3(playerPosX, 5), player.transform.rotation);
        }
        if (playerRb.transform.position.y > 5)
        {
            Instantiate(player, new Vector3(playerPosX, -5), player.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.W) && isOnGround == true)
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
            isOnGround = false;
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * inputHoriz); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}
