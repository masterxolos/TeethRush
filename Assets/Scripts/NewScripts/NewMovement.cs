using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private float horSpeed;

    private float hor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hor * horSpeed * Time.deltaTime, 0, movementSpeed * Time.deltaTime));
    }
}
