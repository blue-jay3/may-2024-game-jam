using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameController : MonoBehaviour
{
    public List<GameObject> objects;
    public GameObject fireflyText;
    private int fireflyCount;
    private Vector3 gayBabyJail;

    
    void Start()
    {
        fireflyCount = 0;
        gayBabyJail = new Vector3(0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //Manages Undos
        PlayerMovement playerScript = objects[0].GetComponent<PlayerMovement>();
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            && playerScript.moving == false)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<undo_script>().move();
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerScript.movePlayer(1f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerScript.movePlayer(-1f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerScript.movePlayer(0f, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerScript.movePlayer(0f, -1f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q)) //undo
        {
            print("restartong!");
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<undo_script>().undo();
                if (!objects[i].activeInHierarchy && objects[i].GetComponent<Transform>().position != gayBabyJail)
                {
                    fireflyAdd(objects[i]);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R)) //Restart
        {
            print("restartong!");
            for (int i = 0; i < objects.Count; i++)
            {
                print("restartong!");
                objects[i].GetComponent<undo_script>().restart();
                if (!objects[i].activeInHierarchy && objects[i].GetComponent<Transform>().position != gayBabyJail)
                {
                    fireflyAdd(objects[i]);
                }
            }
        }

        

        //Manage text
        fireflyText.GetComponent<TextMeshProUGUI>().text = fireflyCount.ToString();
    }

    //Manage Fireflies
    public void fireflyRemove(GameObject firefly)
    {
        firefly.GetComponent<Transform>().position = gayBabyJail;
        firefly.SetActive(false);
        fireflyCount++;
    }
    private void fireflyAdd(GameObject firefly)
    {
        firefly.SetActive(true);
        fireflyCount--;
    }
}
