using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    private CharacterController2D _character;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField]float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        _character = GetComponent<CharacterController2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = _rigidbody2D.position + _character.LastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (var collider2D in colliders)
        {
            ToolHit hit = collider2D.GetComponent<ToolHit>();

            if (hit != null)
            {
                Debug.Log("Ovv someting Hitto!!!");

                hit.Hit();

                break;
            }
        }
    }
}
