using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DarknessBehaviour : MonoBehaviour, IDarknessBehaviour
{

    public bool isHighlighting { get; set; }

    public void Highlighted()
    {
        Debug.Log(gameObject.name + " 光った!");
        isHighlighting = true;
        gameObject.GetComponent<Collider2D>().isTrigger = true;

    }

    public void DisHighlighted()
    {
        Debug.Log(gameObject.name + " 消えた...");
        isHighlighting = false;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
    }

    public void Highlighting()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
