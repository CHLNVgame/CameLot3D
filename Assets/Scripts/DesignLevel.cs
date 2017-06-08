using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignLevel{

//	public int modeLevel = 0;
	public const int MODE_DEFENDE = 0;
	public const int MODE_ATTACK = 1;
	public const int MODE_TACTICAL = 2;

	public const int TOTAL_LEVEL = 2;

	public const int MODE_ID = 0;
	public const int HP_CASTLE_TROOP = 1;
	public const int HP_CASTLE_ENEMY = 2;
	public const int TIME_START = 3;
	public const int TIME_NEXT_WAVE = 4;
	public const int TOTAL_ATT = 5;

	public static int[,] INIT_LEVEL = new int[TOTAL_LEVEL,TOTAL_ATT]
	{
		{ MODE_DEFENDE,		1,		1,		10,		5}, //Level 01//     // MODE_ID, HP_CASTLE_TROOP, HP_CASTLE_ENEMY, TIME_START, TIME_NEXT_WAVE
		{ MODE_DEFENDE,		1,		1,		10,		5} 
	};

	public const int ENEMY_01 = 0;
	public const int ENEMY_02 = 1;
	public const int ENEMY_03 = 2;
	public const int ENEMY_04 = 3;
	public const int ENEMY_05 = 4;


	public static int[,] INIT_WAVE_LEVEL = new int[2,5] 
	{
		{ENEMY_01,		5,		1,		0,		2},
		{ENEMY_01,		5,		1,		0,		2}

	};
}
