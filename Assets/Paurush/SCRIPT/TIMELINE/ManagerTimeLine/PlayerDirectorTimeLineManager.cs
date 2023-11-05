using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PlayerDirectorTimeLineManager : MonoBehaviour
{
    PlayableDirector playableDirectors;
    public List<PlayableAsset> playableAssets;
    public bool startAgain;
    float currentPerformBack, currentTimeLineSeconds, actionPerformValue;
    UiManager uiManager;
    TimeLineCollectionStorage timeLineCollectionStorage;
    private void Awake()
    {
        uiManager = FindObjectOfType<UiManager>();
        timeLineCollectionStorage = FindObjectOfType<TimeLineCollectionStorage>();
        //TimelinePauseClip timelinePauseClip = new TimelinePauseClip();
        //timelinePauseClip.Initialize(playableDirectors, playableAssets[0]);
    }

    public void PlayDirectoryAnimation(int id)
    {
        playableDirectors.Play(playableAssets[id]);
    }

    public void PauseDirectoryAnimation()
    {
        playableDirectors.Pause();
        Debug.Log("pause");

    }

    public void StopDirectoryAnimation()
    {

        playableDirectors.Stop();
        Debug.Log("stop");

    }

    public void ResumeDirectoryAnimation()
    {
        playableDirectors.Resume();
        Debug.Log("resume");


    }

    /// <summary>
    /// jump and start play time line
    /// </summary>
    /// <param name="value"></param>
    public void ChangeTimeLineValuePosition(float value)
    {
        //playableDirectors.DeferredEvaluate();
        //Debug.Log("play111");
        playableDirectors.time = value ;
        playableDirectors.Evaluate();
        playableDirectors.RebuildGraph();
        playableDirectors.playableGraph.GetRootPlayable(0).SetSpeed(1);

        //playableDirectors.Play();

    }



    /// <summary>
    /// Control timeline pause, play and reverse play
    /// </summary>
    /// <param name="value">0,1,-1 => pause, play, reverse </param>
    public void ControlPausePlayReverseSpeed(float value, float performBacktime, float performTime, bool notPerform)
    {
        currentPerformBack = performBacktime;
        switch (value)
        {
                // play or replay
            case 1:
                //  reach to end of perform back so replay not pause
                if (playableDirectors.time >= performBacktime)
                {
                    if (!notPerform)
                    {

                    ChangeTimeLineValuePosition(performTime);
                    Debug.Log("Replay");
                    }
                    else
                    {
                    Debug.Log("Action_Replay");

                    ChangeTimeLineValuePosition(actionPerformValue);
                    }
                    startAgain = true;

                }
                // not reach to end of perform bac time so continue play
                else
                {
                    if (!startAgain)
                    {
                        //Play: just started the process
                        startAgain = true;
                        ChangeTimeLineValuePosition(performTime);
                        Debug.Log("Play");

                    }
                    else
                    {
                        // RESUME: continue playing when user pree play button after pause 
                        playableDirectors.time = currentTimeLineSeconds;
                        playableDirectors.playableGraph.GetRootPlayable(0).SetSpeed(value);
                        Debug.Log("Resume");


                    }
                }
                break;
            case 0:
                Debug.Log("pause");
                playableDirectors.time = currentTimeLineSeconds;
                    playableDirectors.playableGraph.GetRootPlayable(0).SetSpeed(value);
                break;
            case 2:
                if (!startAgain)
                {
                    actionPerformValue = performTime;

                    //Play: just started the process
                    startAgain = true;
                    ChangeTimeLineValuePosition(performTime);
                    Debug.Log("ActionPlay");

                }
                break;
            default:
                break;
        }

    }

    //IEnumerator BegainProcess()
    //{
    //    yield return new WaitForSeconds(0);
    //}
    // Start is called before the first frame update
    void Start()
    {
        playableDirectors = GetComponent<PlayableDirector>();
    }

    private void LateUpdate()
    {
        currentTimeLineSeconds = (float)playableDirectors.time;
            //Debug.Log(currentTimeLineSeconds);
        if (playableDirectors.time >= currentPerformBack && startAgain)
        {
            //Debug.Log("startAgain" + playableDirectors.time);
            startAgain = false;
            uiManager.PlayTextUi();
            timeLineCollectionStorage.togglePausePlay = false;
            //playableDirectors.Resume();
        }
    }
}
