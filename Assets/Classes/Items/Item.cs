using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item: MonoBehaviour
{
    abstract public int id { get; }
    abstract public int worth { get; }
}
