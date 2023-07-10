using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    public float playerXPos;
    public float playerYPos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerXPos = player.transform.position.x;
        playerYPos = player.transform.position.y;
    }
}
