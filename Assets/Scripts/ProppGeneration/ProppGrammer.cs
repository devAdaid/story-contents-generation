using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EFunctionIncludeType
{
    None,
    ShouldBeIncluded,
    ShouldBeNotIncluded,
    Optional,
}

public class ProppFunctionCondition
{
    int pairFunctionNumber = 0;

}

public class ProppGrammer
{
    public delegate EFunctionIncludeType MyCheckFunction(ProppMove move, int arg);
    public Dictionary<int, MyCheckFunction> grammers = new Dictionary<int, MyCheckFunction>();
    public Dictionary<int, int> grammerArg = new Dictionary<int, int>();

    public ProppGrammer()
    {
        AddFunctionGrammer(1, Optional, 0);
        AddFunctionGrammer(2, Optional, 0);
        AddFunctionGrammer(3, OnlyWhenFunctionIncluded, 2);
        AddFunctionGrammer(4, Optional, 0);
        AddFunctionGrammer(5, OnlyWhenFunctionIncluded, 4);
        AddFunctionGrammer(6, Optional, 0);
        AddFunctionGrammer(7, OnlyWhenFunctionIncluded, 6);
        AddFunctionGrammer(8, ShouldBeIncluded, 0);
        AddFunctionGrammer(9, Optional, 0);
        AddFunctionGrammer(10, Optional, 0);
        AddFunctionGrammer(11, Optional, 0);
        AddFunctionGrammer(12, ShouldBeIncluded, 0);
        AddFunctionGrammer(13, OnlyWhenFunctionIncluded, 12);
        AddFunctionGrammer(14, WhenFunctionIncluded, 13);
        AddFunctionGrammer(15, Optional, 0);
        AddFunctionGrammer(16, WhenFunctionNotIncludedOptional, 25);
        AddFunctionGrammer(17, Optional, 0);
        AddFunctionGrammer(18, OnlyWhenFunctionIncluded, 16);
        AddFunctionGrammer(19, OnlyWhenFunctionIncluded, 8);
        AddFunctionGrammer(20, OnlyWhenFunctionIncluded, 11);
        AddFunctionGrammer(21, Optional, 0);
        AddFunctionGrammer(22, OnlyWhenFunctionIncluded, 21);
        AddFunctionGrammer(23, Optional, 0);
        AddFunctionGrammer(24, Optional, 0);
        AddFunctionGrammer(25, WhenFunctionNotIncludedOptional, 18);
        AddFunctionGrammer(26, OnlyWhenFunctionIncluded, 25);
        AddFunctionGrammer(27, OnlyWhenFunctionIncluded, 17);
        AddFunctionGrammer(28, OnlyWhenFunctionIncluded, 24);
        AddFunctionGrammer(29, Optional, 0);
        AddFunctionGrammer(30, Optional, 0);
        AddFunctionGrammer(31, Optional, 0);
    }

    public void AddFunctionGrammer(int number, MyCheckFunction checkFunc, int arg)
    {
        grammers.Add(number, checkFunc);
        grammerArg.Add(number, arg);
    }

    public EFunctionIncludeType GetFunctionIncludeType(ProppMove move, int functionNumber)
    {
        return grammers[functionNumber].Invoke(move, grammerArg[functionNumber]);
    }

    public EFunctionIncludeType ShouldBeIncluded(ProppMove move, int arg)
    {
        return EFunctionIncludeType.ShouldBeIncluded;
    }
    
    public EFunctionIncludeType OnlyWhenFunctionIncluded(ProppMove move, int arg)
    {
        return (move.FindFunction(arg) != null) ? EFunctionIncludeType.ShouldBeIncluded : EFunctionIncludeType.ShouldBeNotIncluded;
    }

    public EFunctionIncludeType WhenFunctionIncluded(ProppMove move, int arg)
    {
        return (move.FindFunction(arg) != null) ? EFunctionIncludeType.ShouldBeIncluded: EFunctionIncludeType.Optional;
    }

    public EFunctionIncludeType WhenFunctionNotIncludedOptional(ProppMove move, int arg)
    {
        return (move.FindFunction(arg) != null) ? EFunctionIncludeType.ShouldBeNotIncluded : EFunctionIncludeType.Optional;
    }

    public EFunctionIncludeType Optional(ProppMove move, int arg)
    {
        return EFunctionIncludeType.Optional;
    }
}