using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLight : MonoBehaviour
{
    [SerializeField] private float LightRadius = 3.5f;

    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position.Set(
            transform.position.x,
            transform.position.y,
            1f
            );

        foreach (
            RaycastHit2D r
            in
            Physics2D.CircleCastAll(transform.position, LightRadius * 0.5f * 0.95f, transform.forward))
        {
            Debug.Log("hit! " + r.collider.gameObject.name);

            IDarknessBehaviour obj = r.collider.gameObject.GetComponent<IDarknessBehaviour>();

            if (obj != null)
            {
                obj.isHighlighting = true;

                obj?.Highlighted();
            }
        }
    }
}
