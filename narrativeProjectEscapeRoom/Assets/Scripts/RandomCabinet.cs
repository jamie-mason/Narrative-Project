using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCabinet: MonoBehaviour
{
    private uint randomNumberSafe = 0;

    private void Start()
    {
        randomNumberSafe = (uint)Random.Range(1, 4);

    }

    public uint getRandomNumberSafe()
    {
        return randomNumberSafe;
    }
}
