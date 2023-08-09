using System;
using UnityEngine;

namespace QFramework.FlappyBird
{
	public partial class SceneController : ViewController
	{
		void Start()
		{
			Debug.Log("UIPanel");
			//设置分辨率 高对齐
			UIKit.Root.SetResolution(720,1280,1);
			//打开分数显示Panel
			UIKit.OpenPanel<UIGamePanel>();
		}

		private void OnDestroy()
		{
			try
			{
				UIKit.ClosePanel<UIGamePanel>();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			
		}
	}
}
