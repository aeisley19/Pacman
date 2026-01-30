using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject startNode;
    [SerializeField] private float speed;
    private Vector3 direction;
    private GameObject currentNode;
    private GameObject nextNode;
    private bool canMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = false;
        nextNode = startNode;
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> possibleNodes;

        direction = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));

        if(Vector2.Distance(transform.position, nextNode.transform.position) <= 0.01f)
        {
            canMove = false;
            currentNode = nextNode;
            possibleNodes = currentNode.gameObject.GetComponent<NodeController>().GetPossibleNextNodes();

            foreach(GameObject node in possibleNodes)
            {
                //Distance to next node.
                Vector3 heading = node.transform.position - transform.position;
                Vector3 directionToNode = heading/heading.magnitude;
                print(node.name + " " + directionToNode);

                if(direction == directionToNode)
                {
                    canMove = true;
                    nextNode = node;
                    break;
                }

                print(canMove);
            }

            print("current position " + transform.position);
            print("left node " + possibleNodes[1].transform.position);
        }

        if(canMove) rb.MovePosition(transform.position + speed * direction * Time.deltaTime);
    }
}
