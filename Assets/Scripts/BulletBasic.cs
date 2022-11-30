using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class BulletBasic : MonoBehaviour
{
    private Vector3 shootDir;
    private float decay;
    private bool gameEnded;
    [SerializeField] private Rigidbody rb;
    

    public void Setup(Vector3 _shootDir, Vector3 _position, float _decay, float _thrust)
    {
        shootDir = _shootDir;
        decay = _decay;
        transform.position = _position;
        transform.eulerAngles = shootDir;
        this.enabled = true;
        rb.AddForce(transform.forward * _thrust, ForceMode.Impulse);
        // Decay
        Decay();
    }

    private async void Decay()
    {
        await Task.Delay((int)decay * 1000); // Convert seconds to miliseconds await to destroy.
        if (this.gameObject != null)
        {
            Addressables.Release(this.gameObject);
        }
    }
}
