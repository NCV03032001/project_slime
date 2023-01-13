using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public int hp;
    public int maxHp = 5;

    public int atk;
    public int maxAtk = 100;
     
    public int def;
    public int maxDef = 100 ;

    public float mana;
    public float maxMana = 100;

    public float speed = 10f;

    public float jumpHeight = 20f;
    public float fallSpeed = 8f;
    private bool isJumping= false;

    public int gold = 0;

    private float direction = 0f;

    Rigidbody2D slime;
    private Animator anim;

    public Transform groundCheck;
    public float groundCheckRadius = 1f;
    public LayerMask groundLayer;
    private bool isGrounded= true;

    // Start is called before the first frame update
    void Start()
    {
        //maxHp= 100;
        hp = maxHp;

        //maxAtk = 100;
        atk = maxAtk;

        //maxDef = 100;
        def = maxDef;

        //maxMana = 100;
        mana = maxMana;

        //speed = 10f;

        //jumpHeight = 20f;
        //fallSpeed = 8f;
        //isJumping = false;

        //gold = 0;

        slime = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        //isGrounded = true;
        //groundCheckRadius = 1f;
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
        
        direction = Input.GetAxis("Horizontal");

        if (direction < 0f)
        {
           slime.velocity = new Vector2(direction * speed, slime.velocity.y);
            transform.localScale = new Vector3(-7.962501f, 7.6125f, 1);
        }
        else if (direction > 0f)
        {
            slime.velocity = new Vector2(direction * speed, slime.velocity.y);
            transform.localScale = new Vector3(7.962501f, 7.6125f, 1);
        }
        /*else
        {
            slime.velocity = new Vector2(0, slime.velocity.y);
        }*/

        if (Input.GetKeyDown(KeyCode.X) && isGrounded)
        //if (Input.GetButtonDown("Jump"))
        {    
            slime.velocity= new Vector2(slime.velocity.x, jumpHeight);
        }
        //print(isGrounded);
        if (slime.velocity.y <= 0)
        {
            slime.gravityScale = 4;
            slime.velocity += Vector2.up * Physics2D.gravity.y * fallSpeed * Time.deltaTime;
        }
        /*else if (slime.velocity.y > 0 && !Input.GetKey(KeyCode.X)) {
            slime.velocity += Vector2.up * Physics2D.gravity.y * (5f - 1) * Time.deltaTime;
        }*/
        anim.SetFloat("speed", Mathf.Abs(slime.velocity.x));
        anim.SetBool("isGround", isGrounded);

    }

    public bool canAttack()
    {
        if (mana > 0)
            return true;

        return false;
    }
}
