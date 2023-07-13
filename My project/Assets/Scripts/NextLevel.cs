using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public bool nextLevel;
    public float level;
    public float baseMove = 27;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLevel = true;
        }

        if (nextLevel == true)
        {
            transform.position = new Vector3(transform.position.x - baseMove, 0);
            nextLevel = false;
            level += 1;
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
    }
}
