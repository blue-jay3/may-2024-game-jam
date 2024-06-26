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
    public LayerMask firefly;
    public Tilemap path;
    public bool moving;
    public gameController gameControllerObj;
    public LayerMask Light;

    // Start is called before the first frame update
    void Start()
    {
        destination.parent = null;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination.position) <= 0.05f)
        {
            moving = false;
        }
        else moving = true;

    }

    public void movePlayer(float x, float y) {
        Collider2D wallResult = Physics2D.OverlapCircle(destination.position + new Vector3(x, y, 0f), 0.2f, wall);
        Collider2D pushResult = Physics2D.OverlapCircle(destination.position + new Vector3(x, y, 0f), 0.2f, canPush);
        Collider2D fireflyResult = Physics2D.OverlapCircle(destination.position + new Vector3(x, y, 0f), 0.2f, firefly);
        Collider2D lightResult = Physics2D.OverlapCircle(destination.position + new Vector3(x, y, 0f), 0.2f, Light);

        if (fireflyResult)
        {
            gameControllerObj.fireflyRemove(fireflyResult.gameObject);
        }
        else if (lightResult)
        {
            if (!wallResult && !pushResult)
            {
                destination.position += new Vector3(x, y, 0f);
            }
            else if (pushResult && !wallResult)
            {
                GameObject obj = pushResult.gameObject;
                PushScript pushScript = obj.GetComponent<PushScript>();
                bool objPushed = pushScript.push(new Vector3(x, y, 0f));
                if (!objPushed && (!path.HasTile(Vector3Int.FloorToInt(destination.position + new Vector3(x, y, 0f))) || path.HasTile(Vector3Int.FloorToInt(destination.position))))
                {
                    pushScript.swap(new Vector3(x, y, 0f));
                    destination.position += new Vector3(x, y, 0f);
                }
                else if (objPushed)
                {
                    destination.position += new Vector3(x, y, 0f);
                }
            }
        }
    }
}
