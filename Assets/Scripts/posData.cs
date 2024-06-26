using System;
using UnityEngine;
public class posData
{
    public Vector3 pos;
    public int counter;
    
    public posData(Vector3 pos, int counter)
    {
        this.pos = pos;
        this.counter = counter;
    }
    public void dec()
    {
        counter--;
    }
}
