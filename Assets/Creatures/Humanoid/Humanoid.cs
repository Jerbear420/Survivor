using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IHumanoid
{

}

public class Humanoid : Creature, ISurvivor
{
   new public static int ID = 2; 
    

    override public int ClassId { get { return ID; } }
    override public IEnumerator Initialize()
    {
        yield return base.Initialize();
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


    public void TakeDamage(int value)
    {
        currentHealth -= value;
        print("health now");
        print(currentHealth);
        if (currentHealth <0)
        {
            Destroy(gameObject);
        }
    }

}
