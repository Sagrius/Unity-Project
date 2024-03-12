using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private int BulletSpeed;

    void OnEnable()
    {
        StartCoroutine(DisableAfterDelay());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * BulletSpeed);
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
