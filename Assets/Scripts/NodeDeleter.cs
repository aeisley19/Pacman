using UnityEngine;

public class NodeDeleter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Wall"))
        {
            print(other.transform.position + other.gameObject.name);
            Destroy(gameObject);
        }

        if(other.CompareTag("WarpZone"))//|| other.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
