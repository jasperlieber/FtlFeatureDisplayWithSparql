using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public float zoomSpeed;

    //public float minX = -360.0f;
    //public float maxX = 360.0f;

    //public float minY = -45.0f;
    //public float maxY = 45.0f;

    //float rotationY = 0.0f;
    //float rotationX = 0.0f;

    //// Use this for initialization
    //void Start()
    //{
    //    //Transform tt = Camera.main.transform;     
    //    rotationX = transform.rotation.x;
    //    rotationY = transform.rotation.y;

    //    Debug.Log(transform.rotation.ToString());
    //}

    void Update()
    {
        var mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (mouseScroll != 0)
        {
            //Debug.Log("mouseScroll=" + mouseScroll + ", deltaTime=" + Time.deltaTime);
            transform.Translate(transform.forward * mouseScroll
                * zoomSpeed * Time.deltaTime, Space.World);  // Space.Self);  // Space.World);
        }

        Vector3 localRight = new Vector3(transform.forward.z, 0, -transform.forward.x);

        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X");
            float rotationY = Input.GetAxis("Mouse Y");

            transform.RotateAround(Vector3.zero, Vector3.up,  Time.deltaTime * speed * rotationX);
            transform.RotateAround(Vector3.zero, localRight, 
                    -Time.deltaTime * speed * rotationY);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += localRight * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= localRight * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

    }
}
