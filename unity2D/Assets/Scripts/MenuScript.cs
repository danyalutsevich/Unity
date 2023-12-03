using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
	[SerializeField]
	GameObject content;

	[SerializeField]
	Toggle WkeyToggle;

	[SerializeField]
	Slider pipePeriodSlider;

	[SerializeField]
	Slider vitalitySlider;

	bool isMenuShown;

	void Start()
	{
		GameState.isWkeyEnabled = WkeyToggle.isOn;
		onPipePeriodSlider(pipePeriodSlider.value);
		onVitalityPeriodSlider(vitalitySlider.value);
		isMenuShown = content.activeInHierarchy;
		ToggleMenu(isMenuShown);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ToggleMenu(!isMenuShown);
		}
	}

	void ToggleMenu(bool show)
	{
		if (show)
		{
			Time.timeScale = 0f;
			isMenuShown = show;
			content.SetActive(show);
		}
		else
		{
			Time.timeScale = 1f;
			isMenuShown = show;
			content.SetActive(show);
		}
	}

	public void onCloseButtonClick()
	{
		content.SetActive(false);
	}

	public void onControlWChanged(bool enabled)
	{
		GameState.isWkeyEnabled = enabled;
	}

	public void onPipePeriodSlider(Single value)
	{
		GameState.pipeSpawnPeriod = 1.5f - value * (1.5f - 0.5f);
	}

	public void onVitalityPeriodSlider(Single value)
	{
		GameState.foodSpawnPeriod = 60f - value * (60f - 20f);
	}
}
