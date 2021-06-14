using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIsland : MonoBehaviour
{
    private bool playerSteppedOnThis = false;
    private bool startRespawnTimer = false;
    [SerializeField] private float startingFallTimer;
    private float fallTimer;
    [SerializeField] private float startingRespawnTimer;
    private float respawnTimer;
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
        fallTimer = startingFallTimer;
        respawnTimer = startingRespawnTimer;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<FlowerPower>().weight == 2)
        {
            Debug.Log("This is happening");
            StartFallTimer();
        }
    }

    public void StartFallTimer()
    {
        playerSteppedOnThis = true;
    }

    private void Update()
    {
        if (playerSteppedOnThis)
        {
            fallTimer -= Time.deltaTime;
        }

        if (fallTimer <= 0.01f)
        {            
            Vector3 temp = new Vector3(0, 60, 0);
            CollapseIsland(temp);
        }

        if (startRespawnTimer)
        {
            respawnTimer -= Time.deltaTime;
        }

        if (respawnTimer <= 0.01f)
        {
            playerSteppedOnThis = false;
            fallTimer = startingFallTimer;
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, 10f);

            if (Vector3.Distance(transform.position, initialPosition) <= 0.001f)
            {
                startRespawnTimer = false;
                respawnTimer = startingRespawnTimer;
                GetComponent<MeshCollider>().enabled = true;
                gameObject.layer = 6;
            }
        }
    }

    private void CollapseIsland(Vector3 _temp)
    {
        transform.position -= _temp * Time.deltaTime;
        GetComponent<MeshCollider>().enabled = false;
        gameObject.layer = 0;
        startRespawnTimer = true;
    }    
}
