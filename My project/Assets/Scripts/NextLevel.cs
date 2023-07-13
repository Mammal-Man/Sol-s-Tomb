using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public bool nextLevel;
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
            transform.position = new Vector3(transform.position.x - 23, 0);
            nextLevel = false;
        }
    }
}
