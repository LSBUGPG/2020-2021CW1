using System.Threading;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    public float speed = 20f;
    public float edge = 10f;
    public Vector2 limit;
    public float scrollSpeed = 20f;
    public float miny = 20f;
    public float maxy = 100f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - edge)
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= edge)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - edge)
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= edge)
        {
            pos.x -= speed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scroll * scrollSpeed * 100f *  Time.deltaTime; 

        pos.x = Mathf.Clamp(pos.x, -limit.x, limit.x);
        pos.z = Mathf.Clamp(pos.z, -limit.y, limit.y);
        pos.y = Mathf.Clamp(pos.y, miny, maxy);

        transform.position = pos;
    }
}
