using UnityEngine;

public class ResenganScript : MonoBehaviour
{
    public float magnitude = 300;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 force = other.transform.position - transform.position;

            RotationScript rotation = GetComponentInChildren<RotationScript>();

            force.Normalize();

            other.gameObject.transform.GetComponent<Rigidbody>().freezeRotation = false;

            other.gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude * other.gameObject.GetComponent<EnemyScript>().speed);
            other.gameObject.transform.Rotate(rotation.rotation * Time.deltaTime * 30, Space.Self);

            other.gameObject.GetComponent<EnemyScript>().hit = true;
        }
    }
}
