using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    public float speed = 3f;
    public bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == false)
            Move();       
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 0.3f)
        {
            transform.LookAt(transform.position -  player.transform.position);
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            //transform.LookAt(player.transform.position,Vector3.up);
            // Check if the position of the cube and sphere are approximately equal.


        }
    }
}
