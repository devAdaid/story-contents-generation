using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ProppFunctionFactory
{
    private Dictionary<int, ConstructorInfo> _constructorInfos = new Dictionary<int, ConstructorInfo>();

    public void Initialize()
    {
        _constructorInfos.Add(1, typeof(Function01_Absentation).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(2, typeof(Function02_Interdiction).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(3, typeof(Function03_Violation).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(4, typeof(Function04_Reconnaissance).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(5, typeof(Function05_Delivery).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(6, typeof(Function06_Trickery).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(7, typeof(Function07_Complicity).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(8, typeof(Function08_VilainyLack).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(9, typeof(Function09_Mediation).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(10, typeof(Function10_Counteraction).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(11, typeof(Function11_Departure).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(12, typeof(Function12_Donor).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(13, typeof(Function13_HeroReaction).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(14, typeof(Function14_MagicalAgent).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(15, typeof(Function15_Guidance).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(16, typeof(Function16_Struggle).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(17, typeof(Function17_Branding).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(18, typeof(Function18_Victory).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(19, typeof(Function19_Liquidation).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(20, typeof(Function20_Return).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(21, typeof(Function21_Persuit).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(22, typeof(Function22_Rescue).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(23, typeof(Function23_UnrecognizedArrival).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(24, typeof(Function24_UnfoundedClaim).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(25, typeof(Function25_Task).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(26, typeof(Function26_Solution).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(27, typeof(Function27_Recognition).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(28, typeof(Function28_Exposure).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(29, typeof(Function29_Transfiguration).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(30, typeof(Function30_Punishment).GetConstructor(Type.EmptyTypes));
        _constructorInfos.Add(31, typeof(Function31_Wedding).GetConstructor(Type.EmptyTypes));
    }

    public ProppFunction CreateFunction(int number)
    {
        ConstructorInfo constructorInfo;
        if (!_constructorInfos.TryGetValue(number, out constructorInfo))
        {
            return null;
        }

        return constructorInfo.Invoke(null) as ProppFunction;
    }
}
