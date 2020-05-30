using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Creature : MonoBehaviour, ISurvivor
{
    public static int ID = 4;
    protected Animator animator;
    [SerializeField] protected int maxHealth;
    protected int currentHealth;

    [SerializeField] protected int baseDamage;
    [SerializeField] protected int baseSpeed;
    protected Rigidbody2D body;

    protected Vector2 facing;


    public virtual int ClassId { get { return ID; } }

    public virtual IEnumerator Initialize()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
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
