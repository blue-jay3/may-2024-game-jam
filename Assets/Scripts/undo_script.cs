using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class undo_script : MonoBehaviour
{
    private int counter;
    private Stack<posData> posList;
    void Start()
    {
        posList = new Stack<posData>();
        posList.Push(new posData(GetComponent<Transform>().position, 0));
        counter = 0;
    }

    public void move(Vector3 pos, bool moved)
    {
        if (moved)
        {
            posList.Push(new posData(GetComponent<Transform>().position, counter));
            counter = 0;
        }
        else
        {
            counter++;
        }
    }

    public Vector3 undo()
    {
        int i = posList.Peek().counter;
        if (i > 0)
        {
            posList.Peek().dec();
            return new Vector3(0f, 0f, 1f);
        }
        else if (posList.Count > 1) return posList.Pop().pos;
        else return posList.Peek().pos;
    }

    public Vector3 restart()
    {
        for (int i = posList.Count; i > 1; i--) posList.Pop();
        return posList.Pop().pos;
    }

    public void setStart(Vector3 pos)
    {
        for (int i = posList.Count; i > 0; i--) posList.Pop();
        posList.Push(new posData(pos, 0));
    }
    
}
