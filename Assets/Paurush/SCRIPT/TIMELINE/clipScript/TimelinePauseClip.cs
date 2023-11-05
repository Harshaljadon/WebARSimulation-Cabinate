using UnityEngine;
using UnityEngine.Playables;

public class TimelinePauseClip : PlayableBehaviour
{
    private double clipEndTime;
    [SerializeField]
    private PlayableDirector director; // Store a reference to the PlayableDirector
    //private PlayableAsset playableAsset1;

    // Initialize the director reference when the script is created
    public void Initialize(PlayableDirector director) //PlayableAsset playableAsset
    {
        this.director = director;
        //this.playableAsset1 = playableAsset;
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        // Calculate the end time of the clip based on its start time and duration
        clipEndTime = playable.GetTime() + 0.001f;

        // Optional: You can cache the original time scale here if needed.
        // float originalTimeScale = Time.timeScale;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        // Check if the current time has passed the calculated clip end time
        if (playable.GetTime() >= clipEndTime)
        {
            // Pause the timeline by pausing the director
            //director.Pause();
            director.playableGraph.GetRootPlayable(0).SetSpeed(0);
            //Debug.Log("call");
        }
    }
}
