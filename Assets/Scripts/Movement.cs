using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject startNode;
    [SerializeField] private float speed;
    [SerializeField] private PlayerInput input;
    private Vector3 direction;
    private GameObject currentNode;
    private GameObject nextNode;
    private Vector3 turnDirection;
    private int turnTimer = 1;

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
        else if ((input.Direction.x == 0 && input.Direction.y != 0) || (input.Direction.x != 0 && input.Direction.y == 0))
        {
            turnDirection = input.Direction;
            print("dir " + direction);
            print("turn " + turnDirection);
        }
  
        transform.position = Vector3.MoveTowards(transform.position, nextNode.transform.position, speed
                * Time.deltaTime);

        if(transform.position == nextNode.transform.position)
        {
            currentNode = nextNode;

            if(currentNode.GetComponent<NodeController>().GetNextNode(turnDirection) != null) 
            {
                direction = turnDirection;
            }
        }

        nextNode = nodeController.GetNextNode(direction) ?? currentNode;
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }
}
