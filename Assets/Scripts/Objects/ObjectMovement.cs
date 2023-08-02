using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    [SerializeField] private float Speed;
    public Transform ObjectMovePoint;
    [SerializeField] private GameObject Player;

    public LayerMask ObjBorder;

    [SerializeField] private LayerMask ObjStatic;

    PlayerBasisMovement playerScript;


    public Transform[] Box;

    void Start()
    {
        ObjectMovePoint.parent = null;
        playerScript = GameObject.FindObjectOfType<PlayerBasisMovement>();
    }

    void FixedUpdate()
    {

        // Add the new position based on the input received 

        NewPosition();

        // Apply Movements

        ObjMovement();


    }

    public void ObjMovement()
    {
        if (!Physics2D.OverlapCircle(ObjectMovePoint.position, 0.2f, ObjStatic))
        {
            if (Box[0].position != Box[1].position && Box[0].position != Box[2].position && Box[2].position != Box[1].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, ObjectMovePoint.position, Speed * Time.deltaTime);
            }
            else
            {
                ObjectMovePoint.position = transform.position;
            }
        }
        else
        {
            ObjectMovePoint.position = transform.position;
        }
    }
    public void NewPosition()
    {
        if (playerScript.InputHorizontal != 0 && playerScript.movePoint.position == ObjectMovePoint.position && !Physics2D.OverlapCircle(ObjectMovePoint.position + new Vector3(playerScript.InputHorizontal, 0, 0), 0.3f, ObjBorder))
        {
            ObjectMovePoint.position += new Vector3(playerScript.InputHorizontal, 0, 0);
        }

        if (playerScript.InputVertical != 0 && playerScript.movePoint.position == ObjectMovePoint.position && !Physics2D.OverlapCircle(ObjectMovePoint.position + new Vector3(0, playerScript.InputVertical, 0), 0.3f, ObjBorder))
        {
            ObjectMovePoint.position += new Vector3(0, playerScript.InputVertical, 0);
        }
    }
}