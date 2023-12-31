using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public bool nextLevel;
    public float level;
    public float baseMove;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (nextLevel == true && gameObject.CompareTag("TileMap"))
        {
            transform.position = new Vector3(transform.position.x - baseMove, transform.position.y);
            nextLevel = false;
            level += 1;
        }

        if (gameObject.CompareTag("Door") && level == 1)
        {
            transform.position = new Vector3(-4.6f, -3.9f);
        }

        if (gameObject.CompareTag("Player") && level == 1)
        {
            transform.position = new Vector3(-10.4f, 1.4f);
        }

        if (level == 5)
        {
            baseMove = 28;
        }
        else
        {
            baseMove = 27;
        }

        if (level > 18)
        {
            baseMove = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLevel = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Door is touched");
            nextLevel = true;
        }
              
    }
}
