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
        MusicController.instance.StopMusic();
        MusicController.instance.PlaySong(MusicController.SongTitles.Root_Map);

        CameraController.instance.Activate( nodes[PlayerController.instance.player.nodeLocation] );

        StartCoroutine(MoveToNextNode());
    }
    
    IEnumerator MoveToNextNode()
    {
        yield return new WaitForSeconds(2);
        currentNodeIndex++;
        PlayerController.instance.player.nodeLocation = currentNodeIndex;
        CameraController.instance.followObject = nodes[currentNodeIndex];
        CameraController.instance.MoveCameraToTarget(nodes[currentNodeIndex].position);
        yield return new WaitForSeconds(3);
        CameraController.instance.Deactivate();
        SceneManager.LoadScene("Battle");
    }
}
