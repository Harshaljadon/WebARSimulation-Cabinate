using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class PauseTimeline : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps => ClipCaps.None;

    // The PlayableDirector and PlayableAsset references will be assigned automatically.
    [SerializeField]
    PlayableDirector director;
    //private PlayableAsset playableAsset;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        // Find the PlayableDirector and PlayableAsset in the hierarchy
        director = owner.GetComponent<PlayableDirector>();
        //playableAsset = this.template;

        var playable = ScriptPlayable<TimelinePauseClip>.Create(graph);
        var timelinePauseClip = playable.GetBehaviour();

        if (director != null) //&& playableAsset != null
        {
            timelinePauseClip.Initialize(director); //playableAsset
        }
        else
        {
            Debug.LogError("PauseTimeline: PlayableDirector or PlayableAsset not found. Make sure they exist in the hierarchy.");
        }

        return playable;
    }
}