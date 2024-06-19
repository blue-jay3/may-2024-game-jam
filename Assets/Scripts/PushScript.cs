using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushScript : MonoBehaviour
{
    public float speed = 25f;
    public Transform destination;
    public LayerMask wall;
    public LayerMask canPush;

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
        Collider2D pushResult = Physics2D.OverlapCircle(destination.position + checkPos, 0.2f, canPush);
        if (!result && !pushResult) {
            destination.position += checkPos;
            return true;
        }
        else if(pushResult && pushResult.gameObject.GetComponent<PushScript>().push(checkPos))
        {
            destination.position += checkPos;
            return true;
        }
        else {
            return false;
        }
    }
    public void swap(Vector3 checkPos)
    {
        destination.position -= checkPos;
    }
}
