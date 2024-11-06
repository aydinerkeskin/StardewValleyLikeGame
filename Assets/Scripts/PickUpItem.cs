using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Transform _player;

    [SerializeField]
    float speed = 3.5f;

    [SerializeField]
    float pickUpDistance = 1.5f;

    [SerializeField]
    float ttl = 10.0f;

    private void Awake()
    {
        _player = GameManager.Instance.Player.transform;
    }

    private void Update()
    {
        ttl = ttl - Time.deltaTime;
        if (ttl < 0)
        {
            Debug.Log("ttl expired!!!");

            Destroy(gameObject);
        }

        // Yerdeki alınabilir objeyle, oyuncunun arasındaki mesafe tespit ediliyor.
        float distance = Vector3.Distance(transform.position, _player.position);

        if (distance > pickUpDistance)
        {
            // Yerden alınabilir ojeye yakın değilsek, oyuncunun yanına çekmeyeceğiz.
            return;
        }

        // Yerden alınabilir ojeye yakın, oyuncunun yanına çekeceğiz.
        transform.position = Vector3.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            Debug.Log("pick up item.");

            // Yerden alınabilir obje 0.1f den yakınsa, tamamen sahneden kaldırılıyor.
            Destroy(gameObject);
        }
    }
}
