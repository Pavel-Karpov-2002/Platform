using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSrcipt : MonoBehaviour
{
    [SerializeField] private PlayerAnimation anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int jump;
    [SerializeField] private float speed;
    [SerializeField] private float groundDistance;

    private float _moveHorizontal;
    private bool _isGrounded;

    private void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
    }

    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
       // anim.Animation = Animation.Idle;
    }

    private void MovePlayer()
    {
        if (_moveHorizontal > 0.1f || _moveHorizontal < -0.1f)
        {
            rb.AddForce(new Vector2(_moveHorizontal * speed, 0), ForceMode2D.Impulse);
            anim.Animation = Animation.Run;
            if (_moveHorizontal < -0.1f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
    }

    private void JumpPlayer()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);
        Debug.Log(_isGrounded);
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            anim.Animation = Animation.Jump;
        }
    }
}
