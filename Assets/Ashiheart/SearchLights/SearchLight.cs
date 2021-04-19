using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UniRx;

public class SearchLight : MonoBehaviour
{
    [SerializeField] private float LightRadius = 3.5f;

    public IObserver<UniRx.Unit> PlayerEnterSubject => playerEnterSubject;

    public enum PlayerState {  Enter, Exit, Stay }

    private Subject<UniRx.Unit> playerEnterSubject = new Subject<UniRx.Unit>();

    private RaycastHit2D[] pre_target = new RaycastHit2D[0];
    private RaycastHit2D[] target = new RaycastHit2D[0];

    private Vector3 pos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (transform.position != pos)
        {
            transform.position = new Vector3(
                pos.x,
                pos.y,
                1f
                );

            target = Physics2D.CircleCastAll(transform.position, LightRadius * 0.5f * 0.95f, transform.forward);

            foreach (var r in target.Intersect(pre_target, new RaycastHit2DComparer()))
            {
                r.collider.gameObject.GetComponent<IDarknessBehaviour>()?.Highlighting();
            }

            foreach (var r in target.Except(pre_target, new RaycastHit2DComparer()))
            {
                r.collider.gameObject.GetComponent<IDarknessBehaviour>()?.Highlighted();
            }

            foreach (var p in pre_target.Except(target, new RaycastHit2DComparer()))
            {
                p.collider.gameObject.GetComponent<IDarknessBehaviour>()?.DisHighlighted();
            }

            pre_target = new RaycastHit2D[target.Length];
            target.CopyTo(pre_target, 0);
        }
    }
    private class RaycastHit2DComparer : IEqualityComparer<RaycastHit2D>
    {
        public bool Equals(RaycastHit2D lhs, RaycastHit2D rhs)
        {
            return string.Equals(lhs.collider.gameObject.name, rhs.collider.gameObject.name);
        }

        public int GetHashCode(RaycastHit2D rh2d)
        {
            if (ReferenceEquals(rh2d, null)) return 0;

            int hashProductName = rh2d.collider.gameObject.name == null ? 0 : rh2d.collider.gameObject.name.GetHashCode();

            int hashProductCode = rh2d.collider.gameObject.GetHashCode();

            return hashProductName ^ hashProductCode;
        }

    }

}
