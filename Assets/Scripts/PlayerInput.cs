using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] Animator animator;
    private bool right;
    private bool left;
    private bool up;
    private bool down;
    public Vector3 Direction { get; private set; }

    void Start()
    {
        Direction = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        up = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        down = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        left = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
        right = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);

        if(right)
        {
            Direction = Vector2.right;
        }
        if(left)
        {
            Direction = Vector2.left;        
        }
        if(up)
        {
            Direction = Vector2.up;
        }
        if(down)
        {
            Direction = Vector2.down;
        }
    }
}
