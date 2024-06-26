using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class undo_script : MonoBehaviour
{
    private Stack<Vector3> posList;
    public Transform destination;
    void Start()
    {
        posList = new Stack<Vector3>();
        posList.Push(destination.position);
    }

    public void move()
    {
           posList.Push(destination.position);
    }

    public void undo()
    {
        if (posList.Count > 1) destination.position= posList.Pop();
        else destination.position= posList.Peek();
    }

    public void restart()
    {
        for (int i = posList.Count; i > 1; i--) posList.Pop();
        destination.position= posList.Peek();
    }

    public void setStart(Vector3 pos)
    {
        for (int i = posList.Count; i > 0; i--) posList.Pop();
        posList.Push(pos);
    }
}
