using UnityEngine;
using UnityEngine.PlayerLoop;

namespace QFramework.FlappyBird
{

    //游戏状态
    public enum GameStates
    {
        NotStart,
        Started,
        GameOver
    }
    

    public class FlappyBird : Architecture<FlappyBird>
    {
        public static BindableProperty<GameStates> GameState = new BindableProperty<GameStates>(GameStates.NotStart);
        public static BindableProperty<int> Score = new BindableProperty<int>();
        public static BindableProperty<int> BestScore = new BindableProperty<int>();
        protected override void Init()
        {
            GameState.RegisterWithInitValue(state =>
            {
                if (state == GameStates.Started)
                {
                    Score.Value = 0;
                }else if (state == GameStates.GameOver)
                {
                    Time.timeScale = 0;
                    UIKit.OpenPanel<UIGameOver>();
                }else if (state == GameStates.NotStart)
                {
                    Score.Value = 0;
                    Time.timeScale = 1;
                }
            });

            BestScore.Value = PlayerPrefs.GetInt(nameof(BestScore));
            BestScore.Register(bestScore =>
            {
                PlayerPrefs.SetInt(nameof(BestScore), bestScore);
            });
            Score.RegisterWithInitValue(score =>
            {
                if (score > BestScore.Value)
                {
                    BestScore.Value = score;
                }
            });

        }

        //调用时机设置--在场景加载之前进行初始化
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitFramework()
        {
            Debug.Log("Panel Inite");
            //初始化UI面板
            ResKit.Init();
            var acr = FlappyBird.Interface;
        }
        
        
    }
}

