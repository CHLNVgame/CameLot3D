using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour {



	public const int TOTAL_LEVEL_ATT = 2;
	public const int TOTAL_ENEMY_ATT = 5;

	public const int HP_ENEMY = 0;
	public const int SPEED_ENEMY = 1;
	public const int DAMGE_ENEMY = 2;
	public const int RANGE_ENEMY = 3;
	public const int ATTACK_DELAY_ENEMY = 4;

	public static float[,] SKELETON_GRUNT_ATT = new float[TOTAL_LEVEL_ATT,TOTAL_ENEMY_ATT]
	{
		{10,	1,		2,		1.5f,		3},// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{10,	1,		2,		1.5f,		3}
	};
	
	public static float[,] SKELETON_ARCHER_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_ENEMY_ATT] 
	{
		{ 10,	1,		2,		5,		3 },// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{ 10,	1,		2,		5,		3 }
	};

	public static float[,] SKELETON_WARRIOR_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_ENEMY_ATT] 
	{
		{ 10,	1,		2,		1.5f,		3 },// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{ 10,	1,		2,		1.5f,		3 }
	};

	public static float[,] SKELETON_FLUTE_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_ENEMY_ATT] 
	{
		{ 10,	1,		2,		5,		3 },// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{ 10,	1,		2,		5,		3 }
	};

	public static float[,] SKELETON_SIEGE_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_ENEMY_ATT] 
	{
		{ 20,	1,		2,		1.5f,		3 },// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{ 20,	1,		2,		1.5f,		3 }
	};



    // Total troop
    public const int TOTAL_TROOP = 9;
    public static float[] FOOD_REQUIRE_TROOP = new float[TOTAL_TROOP] 
    {
        10, 20, 30, 40, 50, 60, 70, 80, 90
    };
    public static float[] TIME_NEXT_TROOP = new float[TOTAL_TROOP] 
    {
        5, 6, 7, 8, 9, 10, 11, 12, 13
    };

    public const int HP_TROOP = 0;
	public const int SPEED_TROOP = 1;
	public const int DAMGE_TROOP = 2;
	public const int DAMGE_SPEC_TROOP = 3;
	public const int RANGE_TROOP = 4;
	public const int ATTACK_DELAY_TROOP = 5;
	public const int RATIO_SPEC_TROOP = 6;
	public const int TOTAL_TROOP_ATT = 7;

    
    public static float[,] TROOP_STREET_FIGHTER_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		1.5f,		3, 		15}, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	1.5f,		3, 		15}
	};

	public static float[,] TROOP_ROBINHOOD_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		5,		3, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	5,		3, 		15 }
	};
	public static float[,] TROOP_ROYAL_GUARD_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		1.5f,		3, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	1.5f,		3, 		15 }
	};
	public static float[,] TROOP_ROCKY_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		1.5f,		3, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	1.5f,		3, 		15 }
	};
	public static float[,] TROOP_DEFEND_GUARDIAN_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		1.5f,		3, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	1.5f,		3,		15 }
	};
	public static float[,] TROOP_BOOMER_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		5,		3, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	5,		3, 		15 }
	};
	public static float[,] TROOP_CENTAUR_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		1.5f,		3, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	1.5f,		3, 		15 }
	};
	public static float[,] TROOP_WIZARD_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		5,		3, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	5,		3, 		15 }
	};
	public static float[,] TROOP_DRAGON_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 20,	1,		2,		5,		5,		3, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, FOOD_REQUIRE_TROOP, TIME_NEXT_TROOP, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	5,		3, 		15 }
	};
	
}
