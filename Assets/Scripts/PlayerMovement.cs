using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float Speed = 3f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX,moveY).normalized;

        playerAnimator.SetFloat("Horizontal",moveX);
        playerAnimator.SetFloat("Vertical",moveY);
        
    }
    private void FixedUpdate()
    {
        //Fisicas
        playerRb.MovePosition(playerRb.position + moveInput * Speed * Time.fixedDeltaTime);

    }
}
