using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject cameraGameObject;
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        body.angularVelocity = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
        if(Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.y += Input.GetAxis("Mouse X");
            transform.eulerAngles = eulerAngles;

            eulerAngles = cameraGameObject.transform.eulerAngles;
            eulerAngles.x -= Input.GetAxis("Mouse Y");
            cameraGameObject.transform.eulerAngles = eulerAngles;

            Vector3 moveVector = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
                moveVector += transform.forward * 3f;
            if (Input.GetKey(KeyCode.S))
                moveVector += -transform.forward * 3f;
            if (Input.GetKey(KeyCode.D))
                moveVector += transform.right * 3f;
            if (Input.GetKey(KeyCode.A))
                moveVector += -transform.right * 3f;

            body.velocity = new Vector3(moveVector.x, body.velocity.y, moveVector.z);

            if(Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(body.velocity.y) <= 0.01f) {
                Vector3 velocity = body.velocity;
                velocity.y = 5;
                body.velocity = velocity;
            }

            if(Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = cameraGameObject.transform.position;
                Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();
                bulletBody.velocity = cameraGameObject.transform.forward * 25f;
            }
        }
    }
}