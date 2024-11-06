using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField]
    GameObject pickUpDrop;

    [SerializeField]
    int dropCount = 5;

    [SerializeField]
    float spread = 0.7f;

    public override void Hit()
    {
        // Ağaç kesildiğinde "dropCount" kadar kütük oluşturacağız.
        while (dropCount > 0)
        {
            dropCount -= 1;

            // Her bir kütüğün düşeceği kordinatı belirliyoruz.

            // Ağacın o anki kordinatını aldık.
            Vector3 position = transform.position;

            // "spread" + rastgele bir değer üretip, rastgele [X,Y] kordinatları belirledik.
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;

            GameObject go = Instantiate(pickUpDrop);

            go.transform.position = position;
        }

        Destroy(gameObject);
    }
}
