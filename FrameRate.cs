using UnityEngine;
using UnityEngine.UI;

public class FrameRate : MonoBehaviour
{
    // 记录帧数
    private int _frame;
    // 上一次计算帧率的时间
    private float _lastTime;
    // 平均每一帧的时间
    private float _frameDeltaTime;
    // 间隔多长时间(秒)计算一次帧率
    private float _Fps;
    private const float _timeInterval = 0.5f;
    string msg;
    public Text FPS;
    public int globalFrameRate;    

    void Start()
    {
        _lastTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        Application.targetFrameRate = -1;
        FrameCalculate();
        msg = string.Format("Fps:{0}", _Fps);

        if (Time.timeScale > 0.2 && Controller.IsStart)
        {
            FPS.text = msg;
        }
        else { FPS.text = ""; }
        
    }

    private void FrameCalculate()
    {
        _frame++;
        if (Time.realtimeSinceStartup - _lastTime < _timeInterval)
        {
            return;
        }

        float time = Time.realtimeSinceStartup - _lastTime;
        _Fps = _frame / time;
        _frameDeltaTime = time / _frame;

        _lastTime = Time.realtimeSinceStartup;
        _frame = 0;
    }

   
}
