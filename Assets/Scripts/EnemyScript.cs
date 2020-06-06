using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    GameObject player;
    GameObject destination;
    public float speed = 3f;
    public bool hit = false;

    public List<Collider> ragdollParts = new List<Collider>();

    public NavMeshAgent agent;
    public Rigidbody root;

    private void Awake()
    {
        TurnOffRagdoll();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destination = GameObject.FindGameObjectWithTag("Destination");
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == false)
            Move();
    }

    void Move()
    {
        agent.SetDestination(destination.transform.position);
    }

    void TurnOffRagdoll()
    {
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {
                c.attachedRigidbody.isKinematic = true;
                c.isTrigger = true;
                ragdollParts.Add(c);
            }
        }
    }

    void TurnOnRagdoll()
    {
        gameObject.GetComponent<Collider>().enabled = false;

        foreach (Collider c in ragdollParts)
        {
            c.attachedRigidbody.isKinematic = false;
            //c.attachedRigidbody.velocity = Vector3.zero;
            c.isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");

        if(collision.gameObject.tag == "Destination")
        {
            TurnOnRagdoll();

            Vector3 force =  transform.position - collision.transform.position;

            //RotationScript rotation = GetComponentInChildren<RotationScript>();

            force.Normalize();

            agent.isStopped = true;

            //float magnitude = collision.gameObject.GetComponentInChildren<ResenganScript>().magnitude;
            Debug.Log(force);

            Rigidbody[] body = gameObject.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody r in body)
            {
                r.AddForce(1000f * force);
            }

            //other.gameObject.transform.Rotate(rotation.rotation * Time.deltaTime * 30, Space.Self);

            hit = true;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Vector3 force = transform.position - other.transform.position;

        //RotationScript rotation = GetComponentInChildren<RotationScript>();
        TurnOnRagdoll();


        force.Normalize();

        agent.isStopped = true;

        //float magnitude = collision.gameObject.GetComponentInChildren<ResenganScript>().magnitude;
        Debug.Log(force);

        Rigidbody[] body = gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in body)
        {
            r.AddForce(1300f * force);
        }


        hit = true;
    }
}
