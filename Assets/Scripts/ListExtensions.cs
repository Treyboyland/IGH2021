using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int index = UnityEngine.Random.Range(0, list.Count);
            var selected = list[index];
            list[index] = list[i];
            list[i] = selected;
        }
    }
}
