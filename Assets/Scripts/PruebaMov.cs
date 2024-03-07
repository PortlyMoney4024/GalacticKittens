using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PruebaMov : NetworkBehaviour
{
    public float px, py, speed;
    Rigidbody2D rb;

    public GameObject cosovich;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!IsOwner) return;
        movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spawnCosovich();
            spawnCosovichServerRpc();
        }
    }

    void movement()
    {
        px = Input.GetAxis("Horizontal") * speed;
        py = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector2(px, py);
    }

    void spawnCosovich()
    {
        //Instantiate(cosovich, transform.position, Quaternion.identity);
        NetworkObjectSpawner.SpawnNewNetworkObject(cosovich, transform.position);
    }

    [ServerRpc]
    void spawnCosovichServerRpc()
    {
        //Instantiate(cosovich, transform.position, Quaternion.identity);
        NetworkObjectSpawner.SpawnNewNetworkObject(cosovich, transform.position);
    }
}
