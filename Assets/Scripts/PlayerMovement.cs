using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject startNode;
    [SerializeField] private float speed;
    [SerializeField] private PlayerInput input;
    private Vector3 direction;
    private GameObject currentNode;
    private GameObject nextNode;
    private Vector3 turnDirection;
    private float turnTimer = 0;
    private const float TURNTIMERCOUNT = 0.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentNode = startNode;
        direction = Vector3.left;
        nextNode = currentNode.GetComponent<NodeController>().GetNextNode(Vector3.left);
    }

    // Update is called once per frame
    void Update()
    {
        NodeController nodeController = currentNode.GetComponent<NodeController>();

        //Gets next direction
        if(input.Direction == -direction) direction = input.Direction;
        else if(direction != input.Direction)
        {
            if(turnDirection == input.Direction) turnTimer += Time.deltaTime;
            else 
            {
                turnDirection = input.Direction;
                turnTimer = 0;
            }
        }

        //Move to next node.
        transform.position = Vector3.MoveTowards(transform.position, nextNode.transform.position, speed
                * Time.deltaTime);

        if(transform.position == nextNode.transform.position)
        {
            currentNode = nextNode;

            //Resets timer, so player turn to perpendicular node.
            if(turnTimer >= TURNTIMERCOUNT)
            {
                turnTimer = 0;
                input.ResetDirection(direction);
                turnDirection = Vector3.zero;
            }
        
            if(currentNode.GetComponent<NodeController>().GetNextNode(turnDirection) != null && turnTimer <= TURNTIMERCOUNT) 
            {
                direction = turnDirection;
                turnDirection = Vector3.zero;
            }
        }

        nextNode = nodeController.GetNextNode(direction) ?? currentNode;
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }
}
