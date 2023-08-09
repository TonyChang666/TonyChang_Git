using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.FlappyBird
{
	// Generate Id:75a03427-a430-4db0-8039-7089cc5dc7e7
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public UnityEngine.UI.Text BestScoreText;
		[SerializeField]
		public UnityEngine.UI.Text ScoreText;
		[SerializeField]
		public UnityEngine.UI.Text TapToStartText;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BestScoreText = null;
			ScoreText = null;
			TapToStartText = null;
			
			mData = null;
		}
		
		public UIGamePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGamePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGamePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
