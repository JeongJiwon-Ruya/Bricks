using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralBlockSetting {
  public static GameState gameState;
  
	public static float blockSpeed = 0.015f;
  public static float respawnTime = 0.4f;

	public const float PlayerBlockMoveDuration = 0.1f;
	public const int BlockBasePositionX = -400;
  public const int BlockSize = 200;

  public static void Initialize() {
    blockSpeed = 0.015f;
    respawnTime = 0.4f;
  }
}
