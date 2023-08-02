using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBasisMovement : MonoBehaviour

{
    // Move Variables 

    [SerializeField] private float Speed;
    public Transform movePoint;


    // Collider variables

    [SerializeField] private LayerMask BorderLine;
    public LayerMask ObjLayer;
    [SerializeField] private LayerMask ObjStatic;
    [SerializeField] private LayerMask SpikeLayer;

    // Move Counter

    public int moveCounter = 25;
    private Vector3 actualPosition;

    // Scripts

    GameManager gameManager; 
   
    ObjectMovement objScript;

    // Input direction Player
    public float InputHorizontal { get; private set; }
    public float InputVertical { get; private set; }
    private bool hasMovedThisInput;

    // Timer 

    private float timer;
    [SerializeField] private float timerLimit = 0.2f;

    // Control Variables

    private bool isDead;

    // Sound

    [SerializeField] private AudioSource movementSoundEffect;

    void Start()
    {
        // Just to keep the object scenes organized
        movePoint.parent = null;

        objScript = GameObject.FindObjectOfType<ObjectMovement>();

        gameManager = GameObject.FindObjectOfType<GameManager>();

        transform.position = movePoint.position;

        actualPosition = transform.position;
    }

    void Update()
    {

        // Player Input

        InputHorizontal = Input.GetAxisRaw("Horizontal");
        InputVertical = Input.GetAxisRaw("Vertical");

        // Player Movement

        if (!hasMovedThisInput)
        {
            MoveTo();
        }


        if (Vector3.Distance(transform.position, movePoint.position) <= 0.3f)
        {
            if (InputHorizontal != 0 && InputVertical == 0)
            {
                CheckBorderH(InputHorizontal);
            }

            else if (InputVertical != 0 && InputHorizontal == 0)
            {
                CheckBorderV(InputVertical);
            }
        }

        if (hasMovedThisInput && InputHorizontal == 0 && InputVertical == 0)
        {
            hasMovedThisInput = false;
        }

        Timer();

        MoveCounter();

        // Game Over 

        if (moveCounter <= 0 && !isDead) 
        {
            isDead = true;
            gameManager.GameOver();
        }

    }

    private void Timer()
    {
        // Timer to dont let the player hold the input and proceed the movement 

        if (hasMovedThisInput && !Physics2D.OverlapCircle(movePoint.position + new Vector3(InputHorizontal, 0, 0), 0.1f, ObjLayer) || hasMovedThisInput && !Physics2D.OverlapCircle(movePoint.position + new Vector3(InputVertical, 0, 0), 0.1f, ObjLayer))
        {
            timer += Time.deltaTime;
        }
        else { timer = 0; }

        if (timer >= timerLimit)
        {
            movePoint.position = transform.position;
        }
    }

    private void MoveCounter()
    {
        if (transform.position != actualPosition && transform.position == movePoint.position && !Physics2D.OverlapCircle(transform.position,0.2f,SpikeLayer))
        {
            movementSoundEffect.Play();
            actualPosition = transform.position;
            moveCounter--;
        }
    }

    private void MoveTo()
    {

        if (!hasMovedThisInput && !Physics2D.OverlapCircle(movePoint.position, 0.3f, ObjLayer) && !Physics2D.OverlapCircle(movePoint.position, 0.2f, ObjStatic))
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, Speed * Time.deltaTime);
        }
        else
        {
            movePoint.position = transform.position;
        }
    }

    // Check Border Line and add to Move Position Object our new position based on our Inputs
    public void CheckBorderV(float vertical)
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, vertical, 0), 0.2f, BorderLine) && transform.position == movePoint.position)
        {
            movePoint.position += new Vector3(0, vertical, 0);
            hasMovedThisInput = true;
        }
    }

    public void CheckBorderH(float horizontal)
    {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontal, 0, 0), 0.2f, BorderLine) && transform.position == movePoint.position)
        {
            movePoint.position += new Vector3(horizontal, 0, 0);
            hasMovedThisInput = true;
        }

        if (InputHorizontal == 1)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else { GetComponentInChildren<SpriteRenderer>().flipX = false; }
    }

}