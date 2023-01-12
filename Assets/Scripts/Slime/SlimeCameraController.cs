using UnityEngine;

public class SlimeCameraController : MonoBehaviour
{

    public GameObject slime;
    public float offset = 2f;
    public float offsetSmooth = 5f;
    private Vector3 slimePos;



    private void Update()
    {
        slimePos = new Vector3(slime.transform.position.x, transform.position.y, transform.position.z);

        if (slime.transform.localScale.x > 0f) {
            slimePos = new Vector3(slime.transform.position.x + offset, transform.position.y, transform.position.z);
        }
        else
        {
            slimePos = new Vector3(slime.transform.position.x - offset, transform.position.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, slimePos, offsetSmooth * Time.deltaTime);
    }
}