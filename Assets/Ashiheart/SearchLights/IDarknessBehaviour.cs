using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDarknessBehaviour
{
    bool isHighlighting { get; set; }

    void Highlighted();

    void DisHighlighted();
}
