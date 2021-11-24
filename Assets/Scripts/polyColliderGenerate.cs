using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polyColliderGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    PolygonCollider2D collider;
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void update()
    {
        if (collider != null)
            Destroy(collider);
        collider=gameObject.AddComponent<PolygonCollider2D>();
    }
}
