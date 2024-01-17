using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Transform EndPointA;
    [SerializeField] private Transform EndPointB;
    private Transform target;
    public float Speed = 1.0f;
    public bool Active { get; set; }
    void Start()
    {
        Active = true;
        // Démarre en se dirigeant vers le point A
        target = EndPointA;
    }
    void Update()
    {
        MoveTowardsTarget();
    }
    void MoveTowardsTarget()
    {
        if (Active) return;

        if (target != null)
        {
            // Calcule la nouvelle position
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            // Déplace le GameObject vers la nouvelle position
            transform.position = newPosition;
        }

        // Vérifie si le GameObject a atteint la cible
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Alterne la cible
            target = target == EndPointA ? EndPointB : EndPointA;
        }
    }
}
