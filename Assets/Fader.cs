﻿using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField]
    private GameObject fade;
    [SerializeField]
    private float fadeInTime;
    [SerializeField]
    private float fadeOutTime;
    [SerializeField]
    private SceneLoader sceneLoader;

    private SceneType sceneType;

    public float FadeInTime
    {
        get
        {
            return fadeInTime;
        }
    }

    public float FadeOutTime
    {
        get
        {
            return fadeOutTime;
        }
    }

    public void StartFadingToGame()
    {
        fade.SetActive(true);

        sceneType = SceneType.Game;

        StartCoroutine(CallInTime(fadeOutTime));
    }

    public void StartFadingToMenu()
    {
        fade.SetActive(true);

        sceneType = SceneType.Menu;

        StartCoroutine(CallInTime(fadeOutTime));
    }

    public void StartFadingToStore()
    {
        fade.SetActive(true);

        sceneType = SceneType.Store;

        StartCoroutine(CallInTime(fadeOutTime));
    }

    public void StartFadingToLobby()
    {
        fade.SetActive(true);

        sceneType = SceneType.Lobby;

        StartCoroutine(CallInTime(fadeOutTime));
    }

    private void Fade()
    {
        switch (sceneType)
        {
            case SceneType.Game:
                sceneLoader.GoToGame();
                break;
            case SceneType.Lobby:
                sceneLoader.GoToLobbyAndSetScale();
                break;
            case SceneType.Store:
                sceneLoader.GoToStore();
                break;
            case SceneType.Menu:
                sceneLoader.GoToMain();
                break;
            default:
                break;
        }
    }

    private enum SceneType
    {
        Menu, Lobby, Game, Store
    }

    private IEnumerator CallInTime(float time)
    {
        var t = 0f;
        while (t < 1)
        {
            t += Time.unscaledDeltaTime / time;
            yield return null;
        }
        Fade();
    }
}
