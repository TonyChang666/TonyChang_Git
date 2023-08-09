using System;
using UnityEngine;
using QFramework;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace QFramework.FlappyBird
{
	public partial class PipeGenerator : ViewController
	{
		private float mGenerateTime;
		private float mDuration;
		public float DurationMin = 1.0f;
		public float DurationMax = 2.5f;
		//使用对象池
		public static SimpleObjectPool<Pipe> PipePool;
		void Start()
		{
			//隐藏掉模板Pipe
			PipeTemplate.Hide();
			mGenerateTime = Time.time;
			mDuration = Random.Range(DurationMin, DurationMax);

			PipePool = new SimpleObjectPool<Pipe>(() =>
			{
				return PipeTemplate.Instantiate().Hide();
			}, (pipe) =>
			{
				pipe.ResetData();
			},initCount:5);
		}

		private void Update()
		{
			
			//判断游戏状态
			if (FlappyBird.GameState.Value == GameStates.NotStart)
			{
				return;
			}
			//生成管道障碍物
			if (Time.time - mGenerateTime > mDuration)
			{
				mGenerateTime = Time.time;
				var pipe = PipePool.Allocate();
				pipe.LocalPosition(PipeGeneratePos.position).LocalPositionY(Random.Range(-5.0f, 5.0f)).Show();
				mDuration = Random.Range(DurationMin, DurationMax);
			}
		}

		private void OnDestroy()
		{
			PipePool = null;
		}
	}
}
