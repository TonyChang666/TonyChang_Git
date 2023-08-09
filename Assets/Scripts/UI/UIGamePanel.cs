using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.FlappyBird
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
			// please add init code here

			FlappyBird.BestScore.RegisterWithInitValue(bestScore =>
			{
				BestScoreText.text = "Best Score:" + bestScore.ToString();
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			FlappyBird.Score.RegisterWithInitValue(score =>
			{
				ScoreText.text = score.ToString();
			})
			.UnRegisterWhenGameObjectDestroyed(gameObject);

			

			FlappyBird.GameState.RegisterWithInitValue(state =>
			{
				if (state == GameStates.NotStart)
				{
					ScoreText.Hide();
					TapToStartText.Show();
				}else if (state == GameStates.Started)
				{
					ScoreText.Show();
					TapToStartText.Hide();
				}else if (state == GameStates.GameOver)
				{
					ScoreText.Hide();
					TapToStartText.Hide();
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);


		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
