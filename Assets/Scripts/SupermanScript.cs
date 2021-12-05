using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermanScript : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Transform superman;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        superman.position = Vector3.MoveTowards(superman.position, new Vector3(0, 0, -20), speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var direction = transform.position - collision.rigidbody.position;
        collision.rigidbody.AddForce(new Vector3(0,0, -5), ForceMode.Impulse);
    }
}
