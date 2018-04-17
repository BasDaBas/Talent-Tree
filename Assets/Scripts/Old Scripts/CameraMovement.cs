using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;

    public float targetHeight = 12f;
    public float distance = 5f;

    public float maxDistance = 20f;
    public float minDistance = 2.5f;

    public float xSpeed = 250f;
    public float ySpeed = 120f;

    public float yMinLimit = -20;
    public float yMaxLimit = 80;

    public float zoomRate = 20;

    public float rotationDampening = 3f;

    public float theta2 = 0.5f;
 
    private float x = 0f;
    private float y = 0f;

    private Vector3 fwd = new Vector3();
    private Vector3 rightVector = new Vector3();
    private Vector3 upVector = new Vector3();
    private Vector3 movingVector = new Vector3();
    private Vector3 collisionVector = new Vector3();
    private bool isColliding = false;
   
    private Vector3 a1 = new Vector3();
    private Vector3 b1 = new Vector3();
    private Vector3 c1 = new Vector3();
    private Vector3 d1 = new Vector3();
    private Vector3 e1 = new Vector3();
    private Vector3 f1 = new Vector3();
    private Vector3 g1 = new Vector3();
    private Vector3 h1 = new Vector3();
    private Vector3 i1 = new Vector3();

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();

        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (rb)
            rb.freezeRotation = true;

    }

    void LateUpdate()
    {
        if (!target)
            return;

        // If either mouse buttons are down, let them govern camera position
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

        // otherwise, ease behind the target if any of the directional keys are pressed
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            var targetRotationAngle = target.eulerAngles.y;
            var currentRotationAngle = transform.eulerAngles.y;
            x = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, rotationDampening * Time.deltaTime);
        }

        distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        y = ClampAngle(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        var position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -targetHeight, 0));

        // Check to see if we have a collision
        collisionVector = AdjustLineOfSight(transform.position, position);

        // Check Line Of Sight
        if (collisionVector != Vector3.zero)
        {
            Debug.Log("Check Line Of Sight");
            a1 = transform.position;
            b1 = position;
            c1 = AdjustLineOfSight(transform.position, position);
            d1 = c1 - a1;
            e1 = d1.normalized * -1;
            f1 = d1 + e1 * 1;
            g1 = f1 + a1;
            position = g1;

            // check distance player to camera
            h1 = position - a1;
            if (h1.magnitude < 10)
            {
                position = a1 - fwd * 4;
                //position.y = targetPlayer.y;
                theta2 = theta2 + 0.25f;
            }

            // set new camera distance
            h1 = position - a1;
            distance = h1.magnitude;
        }

        // check collision
        if (Physics.CheckSphere(position, 0.5f))
        {
            a1 = transform.position;

            Vector3 newPosition = a1 - fwd * 4;
            newPosition.y = target.position.y;
            theta2 = theta2 + 0.25f;

            // set new camera distance
            h1 = position - a1;
            distance = h1.magnitude;
        }

        position = Vector3.Slerp(transform.position, position, Time.deltaTime * 100);

        transform.rotation = rotation;
        transform.position = position;
    }

    static float ClampAngle(float angle, float min,float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    Vector3 AdjustLineOfSight(Vector3 vecA, Vector3 vecB)
    {
        RaycastHit hit;

        if (Physics.Linecast(vecA, vecB, out hit))
        {
            Debug.Log("I hit something");
            return hit.point;
        }

        return Vector3.zero;
    }
}
