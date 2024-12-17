using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpinn : MonoBehaviour
{
    [SerializeField] float spinnSpeed;
    [SerializeField] float deathRotation;
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        transform.position = player.transform.position;
        transform.Rotate(0, 0, spinnSpeed);
        if (transform.rotation.z <= deathRotation)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerSword>().RemoveSword(gameObject);
        }
    }
}
