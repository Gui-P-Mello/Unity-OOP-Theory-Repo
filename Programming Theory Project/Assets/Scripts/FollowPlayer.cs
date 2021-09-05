using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 25, 0);

    // Update is called once per frame
    void LateUpdate()
    {
        followPlayer();
    }
    private void followPlayer()
    {
        transform.position = PlayerController.Instance.transform.position + offset;
    }
}
