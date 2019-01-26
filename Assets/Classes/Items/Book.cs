using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Item
{
    public override int id
    {
        get { return 1; }
    }

    public override int worth
    {
        get { return 5; }
    }
}
