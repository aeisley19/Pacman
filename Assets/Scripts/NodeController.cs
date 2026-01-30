using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    RaycastHit2D[] upCast;
    RaycastHit2D[] downCast;
    RaycastHit2D[] leftCast;
    RaycastHit2D[] rightCast;

    public List<GameObject> GetPossibleNextNodes()
    {
        List<GameObject> possibleNextNodes = new();

        upCast = Physics2D.RaycastAll(transform.position, Vector3.up, 0.25f, LayerMask.GetMask("Node"));
        downCast = Physics2D.RaycastAll(transform.position, Vector3.down, 0.25f, LayerMask.GetMask("Node"));
        leftCast = Physics2D.RaycastAll(transform.position, Vector3.left, 0.25f, LayerMask.GetMask("Node"));
        rightCast = Physics2D.RaycastAll(transform.position, Vector3.right, 0.25f, LayerMask.GetMask("Node"));

        Debug.DrawLine(transform.position, new Vector3(transform.position.x - 0.25f, transform.position.y, 0), Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Color.red);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + 0.25f, 0), Color.red);

        //[0] is always the origin node.
        if(upCast.Length > 1) possibleNextNodes.Add(upCast[1].collider.gameObject);
        if(downCast.Length > 1) possibleNextNodes.Add(downCast[1].collider.gameObject);    
        if(rightCast.Length > 1) possibleNextNodes.Add(rightCast[1].collider.gameObject);
        if(leftCast.Length > 1) possibleNextNodes.Add(leftCast[1].collider.gameObject);

        return possibleNextNodes;
    }   
}