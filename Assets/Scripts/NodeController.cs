using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    private RaycastHit2D[] upCast;
    private RaycastHit2D[] downCast;
    private RaycastHit2D[] leftCast;
    private RaycastHit2D[] rightCast;
    private List<GameObject> possibleNextNodes;

    public void Awake()
    {
        float rayDistance = 0.25f;
        possibleNextNodes = new();

        upCast = Physics2D.RaycastAll(transform.position, Vector3.up, rayDistance, LayerMask.GetMask("Node"));
        downCast = Physics2D.RaycastAll(transform.position, Vector3.down, rayDistance, LayerMask.GetMask("Node"));
        leftCast = Physics2D.RaycastAll(transform.position, Vector3.left, rayDistance, LayerMask.GetMask("Node"));
        rightCast = Physics2D.RaycastAll(transform.position, Vector3.right, rayDistance, LayerMask.GetMask("Node"));

        Debug.DrawLine(transform.position, new Vector3(transform.position.x - rayDistance, transform.position.y, 0), 
            Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + rayDistance, transform.position.y, 0), 
            Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - rayDistance, 0), 
            Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + rayDistance, 0), 
            Color.red);

        //[0] is always the origin node.
        if(upCast.Length > 1) possibleNextNodes.Add(upCast[1].collider.gameObject);
        if(downCast.Length > 1) possibleNextNodes.Add(downCast[1].collider.gameObject);    
        if(rightCast.Length > 1) possibleNextNodes.Add(rightCast[1].collider.gameObject);
        if(leftCast.Length > 1) possibleNextNodes.Add(leftCast[1].collider.gameObject);

        foreach(GameObject n in possibleNextNodes)
        {
            if(gameObject.tag == "Respawn") print("node " + gameObject.name + " : " +  n.name);
        }
    }

    void Update()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x - 0.24f, transform.position.y, 0), Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + 0.24f, transform.position.y, 0), Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 0.24f, 0), Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + 0.24f, 0), Color.red);

       // foreach(GameObject n in possibleNextNodes) print(gameObject.name + " " + n.name);
    } 

    public GameObject GetNextNode(Vector3 direction)
    {
        Vector3 directionToNode;

        foreach(GameObject node in possibleNextNodes)
        {
            Vector3 heading = node.transform.position - transform.position;
            directionToNode = heading/heading.magnitude;

            if(direction == directionToNode)
            {
                return node;
            }
        }

        return null;
    }
}