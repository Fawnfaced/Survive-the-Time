using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour

{
    
    public float moveForce = 10f;
    public float JumpForce = 11f;
    
    private float movementX;

    public Rigidbody2D myBody;

    private SpriteRenderer sr;
    private Animator an;
    private string W_AN = "Walk";
    private bool isGrounded = true;
    private string t_ground = "Ground";
    private string enemy_t = "Enemy";
    private bool m_FacingRight = true;

    private void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();


    }

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimateP();
        PJump();

    }

    private void FixedUpdate()
    {
        //PJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;



    }


    void AnimateP()
    {
        //right
        if (movementX>0)
        {
            an.SetBool(W_AN, true);
            //sr.flipX = false;
            if (!m_FacingRight) { Flip(); }
        }
        //left
        else if (movementX<0)
        {
            an.SetBool(W_AN, true);
            //sr.flipX = true;
            if (m_FacingRight) { Flip(); }
        }

        else
        {
            an.SetBool(W_AN, false);
        }
    //skakanje
    }
    void PJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(t_ground))
        {
                isGrounded=true;

        }

        if (collision.gameObject.CompareTag(enemy_t))
        { 
           
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
                

    }
    
        
    
}


