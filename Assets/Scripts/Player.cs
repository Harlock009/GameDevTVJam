using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    [SerializeField] float speed = 5f;
    private bool moving;
    [SerializeField] private Vector2 lastMove;

    // Cached References
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        moving = false;
        lastMove = new Vector2(0f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// The player moves based on input
    /// </summary>
    private void Move()
    {
        float horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        float vertical = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
        {
            playerRigidBody.MovePosition(new Vector2(transform.position.x + (horizontal * speed * Time.deltaTime), transform.position.y));
            moving = true;
            lastMove = new Vector2(horizontal, 0f);
        }
        else if (vertical != 0)
        {
            playerRigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y + (vertical * speed * Time.deltaTime)));
            moving = true;
            lastMove = new Vector2(0f, vertical);
        }
        else
            moving = false;

        playerAnimator.SetFloat("Horizontal", horizontal);
        playerAnimator.SetFloat("Vertical", vertical);
        playerAnimator.SetFloat("LastMoveHorizontal", lastMove.x);
        playerAnimator.SetFloat("LastMoveVertical", lastMove.y);
        playerAnimator.SetBool("Walking", moving);
    }
}
