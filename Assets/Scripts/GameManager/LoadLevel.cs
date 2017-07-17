using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

public class LoadLevel : MonoBehaviour {
	public static LoadLevel instance;

    public int level;
	public int modeID;
	public int hpTroopCastle;
	public int hpEnemyCastle;
	public float timeStart;
	public int totalWave;

	public float[,] dataWaves;

	public TextAsset xmlFile;


	void Awake()
	{
		if (instance != null)
			return;
		
		string data = xmlFile.text;
		ParseXmlFile (data);
		instance = this;
	}

	void ParseXmlFile(string xmlData)
	{
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.Load (new StringReader(xmlData));

        if (level == 0) level = 1;
        string xmlPathLevel = "//Levels/Level" + level;
		XmlNodeList myNodeList = xmlDoc.SelectNodes (xmlPathLevel);
		foreach(XmlNode node in myNodeList)
		{
			XmlNode nodeModeID = node.FirstChild;
			XmlNode nodehpTroopCastle = nodeModeID.NextSibling;
			XmlNode nodehpEnemyCastle = nodehpTroopCastle.NextSibling;
			XmlNode nodeTimeStart = nodehpEnemyCastle.NextSibling;
			XmlNode nodeTotalWave = nodeTimeStart.NextSibling;

			modeID = int.Parse (nodeModeID.InnerXml);
			hpTroopCastle = int.Parse (nodehpTroopCastle.InnerXml);
			hpEnemyCastle = int.Parse (nodehpEnemyCastle.InnerXml);
			timeStart = float.Parse (nodeTimeStart.InnerXml);
			totalWave = int.Parse (nodeTotalWave.InnerXml);
		}

		string xmlPathLevelWave = xmlPathLevel + "/Waves";
		XmlNodeList myNodeWaveList = xmlDoc.SelectNodes (xmlPathLevelWave);

		int index = 0;
		dataWaves = new float[totalWave, WaveElement.totalElement];
		foreach(XmlNode node in myNodeWaveList)
		{
			XmlNode enemyType = node.FirstChild;
			XmlNode enemyLevel = enemyType.NextSibling;	
			XmlNode enemyNum = enemyLevel.NextSibling;
			XmlNode enemyLane = enemyNum.NextSibling;
			XmlNode timeNextEnemy = enemyLane.NextSibling;
			XmlNode timeNextWave = timeNextEnemy.NextSibling;
			dataWaves[index,WaveElement.enemyType] = float.Parse (enemyType.InnerXml);
			dataWaves[index,WaveElement.enemyLevel] = float.Parse (enemyLevel.InnerXml);
			dataWaves[index,WaveElement.enemyNum] = float.Parse (enemyNum.InnerXml);
			dataWaves[index,WaveElement.enemyLane] = float.Parse (enemyLane.InnerXml);
			dataWaves[index,WaveElement.timeNextEnemy] = float.Parse (timeNextEnemy.InnerXml);
			dataWaves[index,WaveElement.timeNextWave] = float.Parse (timeNextWave.InnerXml);

			index++;
		}
	}
}

public class WaveElement 
{
	public const int enemyType = 0;
	public const int enemyLevel = 1;
	public const int enemyNum = 2;
	public const int enemyLane = 3;
	public const int timeNextEnemy = 4;
	public const int timeNextWave = 5;
	public const int totalElement = 6;
}
