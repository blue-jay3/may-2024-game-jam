using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PushScript : MonoBehaviour
{
    public float speed = 25f;
    public Transform destination;
    public LayerMask wall;
    public LayerMask canPush;
    public Tilemap path;
    bool onPath = false;

    // Start is called before the first frame update
    void Start()
    {
        destination.parent = null;
        if (path.HasTile(Vector3Int.FloorToInt(transform.position))) { 
            onPath = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        if (!onPath && path.HasTile(Vector3Int.FloorToInt(transform.position))) {
            onPath = true;
        }
    }

    public bool push(Vector3 checkPos) {
        Collider2D result = Physics2D.OverlapCircle(destination.position + checkPos, 0.2f, wall);
        Collider2D pushResult = Physics2D.OverlapCircle(destination.position + checkPos, 0.2f, canPush);
        bool isPath = true;
        if (onPath && !path.HasTile(Vector3Int.FloorToInt(destination.position + checkPos))) {
            isPath = false;
        }

        if (!result && !pushResult && isPath) {
            destination.position += checkPos;
            return true;
        }
        else if(pushResult && pushResult.gameObject.GetComponent<PushScript>().push(checkPos) && isPath)
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
