using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    public float followSpeed = 2.0f;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }



    void LateUpdate()
    {
        float interpolation = followSpeed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);
        this.transform.position = position;

    }
}
