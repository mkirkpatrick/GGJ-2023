using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RootMapController : MonoBehaviour
{
    public List<Transform> nodes;
    public int currentNodeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        CameraController.instance.Activate( nodes[currentNodeIndex] );

        StartCoroutine(CycleNodes());
    }

    IEnumerator CycleNodes()
    {
        yield return new WaitForSeconds(3);
        MoveToNextNode();
        yield return new WaitForSeconds(3);
        MoveToNextNode();
        yield return new WaitForSeconds(3);
        MoveToNextNode();
        yield return new WaitForSeconds(3);
        MoveToNextNode();
        yield return new WaitForSeconds(3);
        MoveToNextNode();
        yield return new WaitForSeconds(3);
        CameraController.instance.Deactivate();
        SceneManager.LoadScene("Ending");

    }
    
    void MoveToNextNode()
    {
        currentNodeIndex++;
        CameraController.instance.followObject = nodes[currentNodeIndex];
        CameraController.instance.MoveCameraToTarget(nodes[currentNodeIndex].position);

    }
}
