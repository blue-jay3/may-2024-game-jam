using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushScript : MonoBehaviour
{
    public float speed = 25f;
    public Transform destination;
    public LayerMask wall;

    // Start is called before the first frame update
    void Start()
    {
        destination.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
    }

    public bool push(Vector3 checkPos) {
        Collider2D result = Physics2D.OverlapCircle(destination.position + checkPos, 0.2f, wall);
        if (!result) {
            destination.position += checkPos;
            return true;
        }
        else {
            return false;
        }
    }
}
