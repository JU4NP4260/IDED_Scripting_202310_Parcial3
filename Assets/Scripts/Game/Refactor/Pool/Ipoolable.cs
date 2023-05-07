using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ipoolable
{
    public void SetUp(float index);
    public void Recycle();
}