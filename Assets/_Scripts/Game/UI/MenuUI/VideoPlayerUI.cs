using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;


public class VideoPlayerUI : MonoBehaviour
{
    [FormerlySerializedAs("videoPlayer")] public VideoPlayer VideoPlayer;
    [FormerlySerializedAs("targetSortingLayerName")] public string TargetSortingLayerName = "YourTargetSortingLayer";

    void Start()
    {
        // Ensure you have a reference to the VideoPlayer component in the Inspector.
        if (VideoPlayer == null)
        {
            VideoPlayer = GetComponent<VideoPlayer>();
        }

        // Change the sorting layer of the Video Player to the target sorting layer.
        VideoPlayer.targetCamera.gameObject.GetComponent<Canvas>().sortingLayerName = TargetSortingLayerName;
    }
}