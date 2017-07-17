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
		{200,	0.3f,		100,		1.5f,		1},// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{10,	1,		2,		1.5f,		3}
	};
	
	public static float[,] SKELETON_ARCHER_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_ENEMY_ATT] 
	{
		{ 50,	1.5f,		200,		5,		3 },// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{ 10,	1,		2,		5,		3 }
	};

	public static float[,] SKELETON_WARRIOR_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_ENEMY_ATT] 
	{
		{ 560,	0.3f,		100,		1.5f,		2 },// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{ 10,	1,		2,		1.5f,		3 }
	};

	public static float[,] SKELETON_FLUTE_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_ENEMY_ATT] 
	{
		{ 200,	1.5f,		50,		5,		3 },// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{ 10,	1,		2,		5,		3 }
	};

	public static float[,] SKELETON_SIEGE_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_ENEMY_ATT] 
	{
		{ 2000,	1.5f,		0,		1.5f,		3 },// HP, SPEED, DAMGE or BUFF, RANGE, DELAY
		{ 20,	1,		2,		1.5f,		3 }
	};



    // Total troop
    public const int TOTAL_TROOP = 10;
    public static float[] FOOD_REQUIRE_TROOP = new float[TOTAL_TROOP] 
    {
       // RH ,Fam,Gua,Rock,StFi,Boom,Cent,Wiza,Drag,Roya
          100, 50, 50, 200, 125, 300, 350, 400, 450, 150
    };
    public static float[] TIME_NEXT_TROOP = new float[TOTAL_TROOP] 
    {
       // RH ,Fam  ,Gua,Rock,StFi,Boom,Cent,Wiza,Drag,Roya
         7.5f, 7.5f, 30,  30,  10,  70,  90, 135, 200, 20
    };

    public const int HP_TROOP = 0;
	public const int SPEED_TROOP = 1;
	public const int DAMGE_TROOP = 2;
	public const int DAMGE_SPEC_TROOP = 3;
	public const int RANGE_TROOP = 4;
	public const int ATTACK_DELAY_TROOP = 5;
	public const int RATIO_SPEC_TROOP = 6;
	public const int TOTAL_TROOP_ATT = 7;

    
 	public static float[,] TROOP_ROBINHOOD_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 300,	1,		20,		5,		18,		1.8f, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP // *DONE BALANCE*
		{ 20,	1,		2,		5,	 	5,		3, 		15 }
	};
    public static float[,] TROOP_FARMER_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT]
    {
            { 300,      24,     25,     0,      0,      0,        0}, // HP, Time Product Food, Food Product, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		    { 20,       1,      2,      5,      5,      3,      15 }
    };
    public static float[,] TROOP_DEFEND_GUARDIAN_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT]
    {
            { 3600, 1,      0,      5,      1.5f,       50,         15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		    { 20,   1,      2,      5,      1.5f,       3,      15 }
    };

    public static float[,] TROOP_ROCKY_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 1600,	1,		200,		5,		1.5f,		40, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	1.5f,		3, 		15 }
	};
    public static float[,] TROOP_STREET_FIGHTER_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT]
    {
        { 300,  1,      200,        5,      1.5f,       5,      15}, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		{ 20,   1,      2,      5,      1.5f,       3,      15}
    };

    public static float[,] TROOP_BOOMER_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 320,	1,		600,		5,		5,		70, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	5,		3, 		15 }
	};
	public static float[,] TROOP_CENTAUR_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 7000,	1,		1200,		5,		1.5f,		100, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	1.5f,		3, 		15 }
	};
	public static float[,] TROOP_WIZARD_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 1000,	1,		1500,		5,		5,		150, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	5,		3, 		15 }
	};
	public static float[,] TROOP_DRAGON_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT] 
	{
		{ 5700,	1,		2000,		5,		5,		200, 		15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		{ 20,	1,		2,		5,	 	5,		3, 		15 }
	};
    public static float[,] TROOP_ROYAL_GUARD_ATT = new float[TOTAL_LEVEL_ATT, TOTAL_TROOP_ATT]
    {
            { 1200, 1,      400,        5,      1.5f,       20,         15 }, // HP, SPEED, DAMGE or BUFF, DAME SPEC, RANGE, DELAY, RATIO_SPEC_TROOP
		    { 20,   1,      2,      5,      1.5f,       3,      15 }
    };
}
