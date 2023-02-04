using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMapController : MonoBehaviour
{
    public List<Transform> nodes;

    // Start is called before the first frame update
    void Start()
    {
        CameraController.instance.Activate( nodes[0] );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
