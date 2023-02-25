using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RootMapController : MonoBehaviour
{
    public List<Transform> nodes;
    Player player;

    public GameObject crossFade;

    private void Awake()
    {
        player = PlayerController.instance.player;
    }

    // Start is called before the first frame update
    void Start()
    {
        MusicController.instance.PlaySong(MusicController.SongTitles.Map_March);

        CameraController.instance.Activate( nodes[PlayerController.instance.player.nodeLocation] );

        GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeIn");

        CameraController.instance.zoomSpeed = 5f;
        CameraController.instance.targetZoom = 3f;

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

        if(currentNodeIndex >= 6)
        {
            FinalNode();
        }
        else
        {
            yield return new WaitForSeconds(2f);
            CameraController.instance.zoomSpeed = 2f;
            CameraController.instance.targetZoom = 1f;
            GameController.instance.crossFade.GetComponent<CrossfadeView>().FadeState("FadeOut");
            yield return new WaitForSeconds(2);
            CameraController.instance.Deactivate();
            SceneManager.LoadScene("TotallyLegitLoadingScreen");
        }
    }

    void FinalNode()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        SpriteRenderer fadeSprite = crossFade.GetComponent<SpriteRenderer>();
        float opacity = 0f;
        float timeElapsed = 0;
        float fadeDuration = 2f;
        while(timeElapsed < fadeDuration)
        {   
            opacity = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            fadeSprite.color = new Color(1f, 1f, 1f, opacity);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        opacity = 1f;
        fadeSprite.color = new Color(1f, 1f, 1f, opacity);

        SceneManager.LoadScene("Ending");
    }
}
