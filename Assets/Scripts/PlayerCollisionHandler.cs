using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Pellet") {
            other.transform.GetChild(0).gameObject.SetActive(false);
            print("supps");
        }
    }
}
