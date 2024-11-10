using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    CharacterController2D characterController;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;
    [SerializeField] HighlightController highlightController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        Check();

        if (Input.GetMouseButtonDown(1))
        {
            UseInteract();
        }
    }

    private void UseInteract()
    {
        Vector2 position = _rigidbody2D.position + characterController.LastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (var collider2D in colliders)
        {
            Interactable interactable = collider2D.GetComponent<Interactable>();

            if (interactable != null)
            {
                Debug.Log("Ovv someting Interacto!!!");

                interactable.Interact(character);

                break;
            }
        }
    }
    private void Check()
    {
        Vector2 position = _rigidbody2D.position + characterController.LastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (var collider2D in colliders)
        {
            Interactable interactable = collider2D.GetComponent<Interactable>();

            if (interactable != null)
            {
                Debug.Log("Ovv someting highlighto!!!");

                highlightController.Highlight(interactable.gameObject);

                return;
            }
        }

        highlightController.Hide();
    }
}
