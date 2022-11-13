using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    private Vector3 shootDir;
    private float decay;
    [SerializeField] private float moveSpeed = 1f;

    public void Setup(Vector3 _shootDir, Vector3 _position, float _decay)
    {
        shootDir = _shootDir;
        decay = _decay;
        transform.position = _position;
        transform.eulerAngles = shootDir;

        this.enabled = true;
    }

    private void FixedUpdate()
    {
        transform.position += (transform.forward * moveSpeed * Time.deltaTime);
    }
}
