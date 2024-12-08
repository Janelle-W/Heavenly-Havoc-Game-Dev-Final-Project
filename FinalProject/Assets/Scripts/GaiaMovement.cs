using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10f;

    [Header("Input Keys")]
    [SerializeField] private KeyCode moveLeftKey = KeyCode.A;
    [SerializeField] private KeyCode moveRightKey = KeyCode.D;
    [SerializeField] private KeyCode moveUpKey = KeyCode.W;
    [SerializeField] private KeyCode moveDownKey = KeyCode.S;

    [Header("Boundaries")]
    [SerializeField] private bool useScreenBounds = true;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (useScreenBounds)
        {
            CalculateScreenBounds();
        }
    }

    private void CalculateScreenBounds()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = spriteRenderer.bounds.size.x / 2;
        objectHeight = spriteRenderer.bounds.size.y / 2;
    }

    private void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(moveLeftKey))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(moveRightKey))
        {
            movement += Vector3.right;
        }
        if (Input.GetKey(moveUpKey))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(moveDownKey))
        {
            movement += Vector3.down;
        }

        Move(movement);
    }

    private void Move(Vector3 movement)
    {
        Vector3 newPosition = transform.position + movement.normalized * speed * Time.deltaTime;

        if (useScreenBounds)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
            newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        }

        transform.position = newPosition;
    }
}