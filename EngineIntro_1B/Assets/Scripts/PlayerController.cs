using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{

    private UnityEngine.Vector2 moveInput;
    private bool isSprint;
    private bool isJump;
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<UnityEngine.Vector2>();
    }

    public void OnSprint(InputValue value)
    {
        isSprint = value.isPressed;
    }

    public void OnJump(InputValue value)
    {
        isJump = value.isPressed;
    }

    // Update is called once per frame
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

        if (isSprint)
        {
            transform.Translate(UnityEngine.Vector3.right * moveInput.x * moveSpeed * 2.0f * Time.deltaTime);
            transform.Translate(UnityEngine.Vector3.up * moveInput.y * moveSpeed * 2.0f * Time.deltaTime);
        }
        else
        {
            transform.Translate(UnityEngine.Vector3.right * moveInput.x * moveSpeed * Time.deltaTime);
            transform.Translate(UnityEngine.Vector3.up * moveInput.y * moveSpeed * Time.deltaTime);
        }
    }
}
