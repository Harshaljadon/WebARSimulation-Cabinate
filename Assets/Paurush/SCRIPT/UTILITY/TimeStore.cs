
[System.Serializable]
public class TimeStore 
{
    public TimePerformdata timePerformdata;
}

[System.Serializable]
public struct TimePerformdata
{
    public float valuStartPointStep;
    public float valuePerformTime;
    public bool isPerformed;
    public float valueActionPerformTime;
    public float valuePerformBack;
    public float valueNextJumpPeformPlayTime;
    public bool isReplayStart;

}
