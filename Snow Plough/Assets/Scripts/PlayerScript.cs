using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // PUBLIC ATTRIBUTES
    public float baseSpeed = 6f;
    public float dashSpeed = 12f;
    public Rect playField = new Rect(-5f, -5f, 10f, 10f);
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
        // Clamping the player to the play field
        Vector3 pos = transform.position;
        if (pos.x < playField.x || pos.x > playField.x + playField.width)
        {
            pos.x = Mathf.Clamp(pos.x, playField.x, playField.x + playField.width);
        }
        if (pos.z < playField.y || pos.z > playField.y + playField.height)
        {
            pos.z = Mathf.Clamp(pos.z, playField.y, playField.y + playField.height);
        }
        transform.position = pos;
    }
}
