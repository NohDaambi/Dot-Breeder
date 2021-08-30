using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 Offset = new Vector3(0, 0, -5f);
    void LateUpdate()
    {
        transform.position = player.transform.position + Offset;
    }
}
