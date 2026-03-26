using System.Numerics;
using NUnit.Framework;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{

    private UnityEngine.Vector2 moveInput;
    private bool isSprint;
    public float jumpForce = 7f;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Animator myAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<UnityEngine.Vector2>();
    }

    public void OnSprint()
    {
        if(isSprint)
        {
            isSprint = false;
        }
        else
        {
            isSprint = true;
        }
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed) // 점프 버튼을 누르면
        {
            rb.linearVelocity = new UnityEngine.Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {

        if(Collision.name == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("PlayScene_" + Collision.name);
        }
    }

    void Update()
    {
        if(moveInput.x > 0)
        {
            transform.localScale = new UnityEngine.Vector3(1, 1, 1);
        }
        else if(moveInput.x < 0)
        { 
            transform.localScale = new UnityEngine.Vector3(-1, 1, 1);
        }

        if(moveInput.magnitude > 0)
        {
            myAnimator.SetBool("move", true);

            if (isSprint)
            {
                transform.Translate(UnityEngine.Vector3.right * moveInput.x * moveSpeed * 2.0f * Time.deltaTime);
            }
            else
            {
                transform.Translate(UnityEngine.Vector3.right * moveInput.x * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            myAnimator.SetBool("move", false);
        }
    }
}
