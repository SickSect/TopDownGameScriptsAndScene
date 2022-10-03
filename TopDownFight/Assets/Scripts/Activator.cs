using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private GameObject arena;
    // Start is called before the first frame update
    void Start()
    {
        arena.SetActive(true);
    }

    
}
