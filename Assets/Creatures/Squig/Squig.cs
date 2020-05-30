using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squig : Creature
{

    new public static int ID = 5;
    private Creature currentTarget;
    public override int ClassId { get { return ID; } }

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        currentTarget = null;
        facing = Vector2.right;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Sight();

    }

    private void Movement()
    {
        if (currentTarget != null)
        {
            body.velocity = (currentTarget.transform.position - transform.position).normalized * baseSpeed;
        }
        else
        {
            //body.velocity = new Vector2(1, 0) * baseSpeed;

        }
    }

    private void Sight()
    {
        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 2;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 50f;

        Vector3[] verticies = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[verticies.Length];
        int[] triangles = new int[rayCount * 3];

        verticies[0] = origin;
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, WorldBehaviour.GetVectorFromAngles(angle), fov);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    currentTarget = hit.collider.GetComponent<Creature>();
                }
            }
            Vector3 vertex = origin + WorldBehaviour.GetVectorFromAngles(angle) * viewDistance;
            verticies[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;

            }
            vertexIndex++;
            angle -= angleIncrease;
        }

    }

    private void StopAction()
    {
        animator.SetTrigger("idleaction");
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print(collision.gameObject.name + " - Name of game object");
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                animator.SetTrigger("paction");
            }

        }
    }
}
