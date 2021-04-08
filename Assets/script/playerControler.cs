

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    bool canJump;
    Rigidbody2D m_Rigidbody2D;
    Animator m_Animator;
    SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            m_Rigidbody2D.AddForce(new Vector2(-500f * Time.deltaTime, 0));
            m_Animator.SetBool("moving", true);
            m_SpriteRenderer.flipX = true;
        }

        if(!Input.GetKey("left") && !Input.GetKey("right"))
        {
            m_Animator.SetBool("moving", false);
        }
        if (Input.GetKey("right"))
        {
            m_Rigidbody2D.AddForce(new Vector2(500f * Time.deltaTime, 0));
            m_Animator.SetBool("moving", true);
            m_SpriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown("up")&& canJump)
        {
            canJump = false;
            m_Rigidbody2D.AddForce(new Vector2(0, 100f));

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if ( collision.transform.tag == "ground")
        {
            canJump = true;

        }
    }



}
