public interface ILifeTimeAble
{
    float LifeTime { get; }
    float ProgressTime { get; }
    void SetLifeTime(float value);
}