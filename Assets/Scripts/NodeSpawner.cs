using UnityEngine;

public class NodeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private float offSetX;
    [SerializeField] private float offSetY;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 nextNodePositon = startPosition;

        while(nextNodePositon.y <= endPosition.y)
        {
            while(nextNodePositon.x <= endPosition.x)
            {
                Instantiate(prefab, nextNodePositon, Quaternion.identity);
                nextNodePositon.x += offSetX;
            }   
                nextNodePositon.x = startPosition.x;
                nextNodePositon.y += offSetY;
        }
    }
}
