using UnityEngine;
using UnityEngine.UI;

public class FrameRate : MonoBehaviour
{
    // ��¼֡��
    private int _frame;
    // ��һ�μ���֡�ʵ�ʱ��
    private float _lastTime;
    // ƽ��ÿһ֡��ʱ��
    private float _frameDeltaTime;
    // ����೤ʱ��(��)����һ��֡��
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
