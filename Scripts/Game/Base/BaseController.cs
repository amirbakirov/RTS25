using UnityEngine;

public class BaseController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tree" ||
            other.gameObject.tag == "stone")
        {
            Destroy(other.gameObject);
        }
    }
}
