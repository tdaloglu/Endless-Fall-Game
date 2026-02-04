using System.Collections;
using UnityEngine;

public class YeniCoroutine
{
    public static IEnumerator GercekZamaniBekle(float zaman)
    {
        float baslangic = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < (baslangic + zaman))
        {
            yield return null;
        }
    }
}
