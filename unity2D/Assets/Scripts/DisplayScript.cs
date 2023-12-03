using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{

	[SerializeField]
	private TMPro.TextMeshProUGUI pipesPassedTMP;

	[SerializeField]
	private Image vitalityIndicator;

	[SerializeField]
	private TMPro.TextMeshProUGUI timer;

	void Start()
	{
	}

	void LateUpdate()
	{
		pipesPassedTMP.text = GameState.pipesPassed.ToString();
		vitalityIndicator.fillAmount = GameState.vitality;
		vitalityIndicator.color = new Color(1 - GameState.vitality, GameState.vitality, 0.3f);
		TimeSpan t = TimeSpan.FromSeconds(Time.realtimeSinceStartup);

		timer.text = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
						t.Hours,
						t.Minutes,
						t.Seconds,
						t.Milliseconds);
	}
}
