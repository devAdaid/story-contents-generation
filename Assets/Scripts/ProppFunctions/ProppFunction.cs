using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppFunction
{
    public virtual int Number
    {
        get { return 0; }
    }

    public virtual string Name
    {
        get { return string.Empty; }
    }

    public override string ToString()
    {
        return $"{Number}: {Name}";
    }
}
