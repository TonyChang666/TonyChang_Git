using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.FlappyBird
{
	// Generate Id:a7fd5dc7-f7cf-4f2d-bece-7957148ca1d8
	public partial class UIGameOver
	{
		public const string Name = "UIGameOver";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnRestart;
		
		private UIGameOverData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnRestart = null;
			
			mData = null;
		}
		
		public UIGameOverData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameOverData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameOverData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
