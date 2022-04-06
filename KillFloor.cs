using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawn_point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death")) //only triggers with the tag death make everything respawn,
                                                  //so the cube wall triggers dont respawn (might add as feature but currently i like the bouncing off wall
        {
            player.transform.position = respawn_point.transform.position;
        }
        
    }
}
