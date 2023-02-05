using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RootMapController : MonoBehaviour
{
    public List<Transform> nodes;
    Player player = PlayerController.instance.player;
    //public int currentNodeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        MusicController.instance.PlaySong(MusicController.SongTitles.Root_Map);

        CameraController.instance.Activate( nodes[PlayerController.instance.player.nodeLocation] );

        StartCoroutine(MoveToNextNode());
    }
    
    IEnumerator MoveToNextNode()
    {
        int currentNodeIndex = player.nodeLocation;
        yield return new WaitForSeconds(2);
        currentNodeIndex++;
        PlayerController.instance.player.nodeLocation = currentNodeIndex;
        CameraController.instance.followObject = nodes[currentNodeIndex];
        CameraController.instance.MoveCameraToTarget(nodes[currentNodeIndex].position);
        player.nodeLocation = currentNodeIndex;
        yield return new WaitForSeconds(3);
        CameraController.instance.Deactivate();
        SceneManager.LoadScene("Battle");
    }
}
