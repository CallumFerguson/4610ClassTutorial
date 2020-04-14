using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Vector3 targetPosition;
    Rigidbody body;

    void Start()
    {
        targetPosition = new Vector3(Random.value * 20 - 10, 0, Random.value * 20 - 10);
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        lookAtPosition(targetPosition);
        Vector3 position = transform.position;
        position.y = 0;
        if (Vector3.Distance(position, targetPosition) > 0.05f)
            body.velocity = transform.forward * 3f;
        else
            targetPosition = new Vector3(Random.value * 20 - 10, 0, Random.value * 20 - 10);
    }

    void lookAtPosition(Vector3 target)
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.rotation = Quaternion.LookRotation(target - position, Vector3.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
