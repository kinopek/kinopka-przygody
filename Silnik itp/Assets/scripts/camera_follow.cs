using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeX;
    public float smoothTimeY;
    public bool bounds;
    public Vector3 min_camera_pos;
    public Vector3 max_camera_pos;

    public GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, min_camera_pos.x, max_camera_pos.x),
               Mathf.Clamp(transform.position.y, min_camera_pos.y, max_camera_pos.y),
               Mathf.Clamp(transform.position.z, min_camera_pos.z, max_camera_pos.z));
        }

    }

    public void SetMinCamPosition()
    {
        min_camera_pos = gameObject.transform.position;
    }

    public void SetMaxCamPostion()
    {
        max_camera_pos = gameObject.transform.position;
    }

}
