using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] Movement movement;
    private bool right;
    private bool left;
    private bool up;
    private bool down;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        up = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        down = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        left = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
        right = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);


       // if(animator.GetFloat("moveX") == 0 )
    }
}
