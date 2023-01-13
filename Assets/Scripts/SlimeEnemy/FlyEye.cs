using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyEye : MonoBehaviour
{
    public AIPath aiPath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-7, 7, 1);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f) 
        {
            transform.localScale = new Vector3(7, 7, 1);
        }
    }
}
