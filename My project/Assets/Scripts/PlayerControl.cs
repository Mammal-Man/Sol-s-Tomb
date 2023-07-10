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
