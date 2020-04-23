using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppFunction
{
    public virtual int Number => 0;
    public virtual string Name => string.Empty;
    public virtual string Designation => string.Empty;

    public override string ToString()
    {
        return $"{Number}: {Name}";
    }
}
