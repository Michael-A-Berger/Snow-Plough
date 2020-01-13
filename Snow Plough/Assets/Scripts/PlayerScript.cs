using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // PUBLIC ATTRIBUTES
    public float baseSpeed = 6f;
    public float dashSpeed = 12f;
    public bool debug = false;

    // PRIVATE ATTRIBUTES
    private Rigidbody thisRigidbody;
    private Vector3 movementVector;
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // DebugLog()
    private void DebugLog()
    {
        Debug.Log("movementVector(x,z): (" + movementVector.x + ", " + movementVector.z + ")");
    }

    // FixedUpdate()
    private void FixedUpdate()
    {
        // Applying the movement vector
        thisRigidbody.MovePosition(thisRigidbody.position + movementVector * movementSpeed * Time.fixedDeltaTime);
    }

    // Update()
    void Update()
    {
        // Updating the movement vector
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");
        movementVector = Vector3.ClampMagnitude(movementVector, 1);
        movementSpeed = baseSpeed;
        if (Input.GetAxis("Jump") > 0.1)
        {
            movementSpeed = dashSpeed;
        }

        // IF debug is enabled, show the debug log
        if (debug) DebugLog();
    }

    // LateUpdate()
    private void LateUpdate()
    {
        
    }
}
