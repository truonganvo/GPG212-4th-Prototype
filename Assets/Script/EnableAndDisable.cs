using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAndDisable : MonoBehaviour
{
    [SerializeField] GameObject enable;

    public void Click()
    {
        enable.SetActive(true);
    }
}
