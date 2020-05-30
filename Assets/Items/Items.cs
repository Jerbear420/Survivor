using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour, ISurvivor
{

    public static int ID = 6;

    public virtual int ClassId { get { return ID; } }

    public virtual IEnumerator Initialize()
    {
        yield return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initialize());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
