using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_at_player : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
    }
    public void rotate() {
        Vector3 playerPosVector = player.transform.position - transform.position;
        playerPosVector = new Vector3(playerPosVector.x, 0, playerPosVector.z);
        transform.rotation = Quaternion.LookRotation(playerPosVector, Vector3.up);
        
    }
}
