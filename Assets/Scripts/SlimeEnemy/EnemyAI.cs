using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 15f;
    public float nextWPD = 3f;

    public Transform gfx;
    private Vector3 startPosition;

    Path path;
    int crrWP = 0;
    bool reachEOP = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker= GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        startPosition = rb.position;
        print(startPosition);

        InvokeRepeating("UpdatePath", 0f, 1f);
    }

    void UpdatePath()
    {
        print(target.position);
        
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            crrWP = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if(crrWP >= path.vectorPath.Count)
        {
            reachEOP = true;
            return;
        }
        else
        {
            reachEOP = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[crrWP] -rb.position).normalized;
        Vector2 force = direction*speed*Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[crrWP]);

        if(distance < nextWPD)
        {
            crrWP++;
        }

        if (force.x >= 0.01f)
        {
            gfx.localScale = new Vector3(-7, 7, 1);
        }
        else if (force.x <= -0.01f)
        {
            gfx.localScale = new Vector3(7, 7, 1);
        }
    }
}
