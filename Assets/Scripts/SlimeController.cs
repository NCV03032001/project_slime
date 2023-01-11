using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public int hp;
    public int maxHp;

    public int atk;
    public int maxAtk;
     
    public int def;
    public int maxDef;

    public float mana;
    public float maxMana;

    public float speed;

    public float jumpHeight;
    public bool isJumping;

    public int gold;

    private float direction = 0f;

    Rigidbody2D slime;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        maxHp= 100;
        hp = maxHp;

        maxAtk = 100;
        atk = maxAtk;

        maxDef = 100;
        def = maxDef;

        maxMana = 100;
        mana = maxMana;

        speed = 5f;

        jumpHeight = 9f;
        isJumping = false;

        gold = 0;

        slime= GetComponent<Rigidbody2D>();
        isGrounded = false;
        groundCheckRadius = 0.2f;
}

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }*/
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        print(isGrounded);
        direction = Input.GetAxis("Horizontal");

        if (direction != 0f) {
            slime.velocity = new Vector2(direction*speed, slime.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.X) && isGrounded)
        //if (Input.GetButtonDown("Jump"))
        {
            slime.velocity= new Vector2(slime.velocity.x, jumpHeight);
        }
    }
}
