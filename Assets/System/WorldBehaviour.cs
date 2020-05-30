using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ISurvivor
{
    int ClassId { get; }
    IEnumerator Initialize();
}

public interface Targetable
{
    bool canTarget { get; }
    bool isTargetable();
}
public class WorldBehaviour : MonoBehaviour, ISurvivor
{

    public static Vector3 GetVectorFromAngles(float angle)
    {
        // angle =  0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angle));
    }

    public static int ID = 1;
    public int ClassId { get { return ID; } }

    public IEnumerator Initialize()
    {
        yield return true;
    }

    void Start()
    {
        StartCoroutine(Initialize());
    }


}
