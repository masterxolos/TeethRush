using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using DG.Tweening;
using UnityEngine;

public class NewCollector : MonoBehaviour
{
    [SerializeField] private ToothManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("CollectableThoot").GetComponent<ToothManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tooth"))
        {
            other.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.13049f,
                transform.position.z - 10f);
            Destroy(gameObject.GetComponent<NewCollector>());
            other.gameObject.AddComponent<NewCollector>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.GetComponent<Animator>().enabled = true;
            other.gameObject.AddComponent<NodeMovement>();
            other.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
            _manager.teeth[_manager.count] = other.gameObject;
            _manager.count++;

            other.gameObject.tag = "CollectedTeeth";
        }

        else if (other.gameObject.CompareTag("Obstacle"))
        {
            _manager.count--;
            _manager.teeth[_manager.count] = null;
            _manager.teeth[_manager.count - 1].gameObject.AddComponent<NewCollector>();
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("damakTrigger"))
        {
            StartCoroutine(_manager.Jump());
        }
    }
}
