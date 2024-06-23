using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 25f;
    public Transform destination;
    public LayerMask wall;
    public LayerMask canPush;
    public Tilemap path;
    public bool canSwap = true;

    // Start is called before the first frame update
    void Start()
    {
        destination.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination.position) <= 0.05f) {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                movePlayer(1f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movePlayer(-1f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                movePlayer(0f, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                movePlayer(0f, -1f);
            }
        }

    }

    void movePlayer(float x, float y) {
        Collider2D wallResult = Physics2D.OverlapCircle(destination.position + new Vector3(x, y, 0f), 0.2f, wall);
        Collider2D pushResult = Physics2D.OverlapCircle(destination.position + new Vector3(x, y, 0f), 0.2f, canPush);

        if (!wallResult && !pushResult)
        {
            destination.position += new Vector3(x, y, 0f);
        }
        else if (pushResult) {
            GameObject obj = pushResult.gameObject;
            PushScript pushScript = obj.GetComponent<PushScript>();
            if (!pushScript.push(new Vector3(x, y, 0f)) && (!path.HasTile(Vector3Int.FloorToInt(destination.position + new Vector3(x, y, 0f))) || path.HasTile(Vector3Int.FloorToInt(destination.position)))) {
                pushScript.swap(new Vector3(x, y, 0f));
            }
            destination.position += new Vector3(x, y, 0f);
        }
    }
}
