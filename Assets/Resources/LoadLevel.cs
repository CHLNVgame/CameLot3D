using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

public class LoadLevel : MonoBehaviour {


	public int modeID;
	public int hpTroopCastle;
	public int hpEnemyCastle;
	public float timeStart;
	public float timeNextWave;
	public int totalWave;

	public List<DataWave> listWaves;



	public TextAsset xmlFile;
	int level = 1;

	void Start()
	{
		string data = xmlFile.text;
		ParseXmlFile (data);
	}

	void ParseXmlFile(string xmlData)
	{
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.Load (new StringReader(xmlData));

		string xmlPathLevel = "//Levels/Level" + level;
		XmlNodeList myNodeList = xmlDoc.SelectNodes (xmlPathLevel);
		foreach(XmlNode node in myNodeList)
		{
			XmlNode nodeModeID = node.FirstChild;
			XmlNode nodehpTroopCastle = nodeModeID.NextSibling;
			XmlNode nodehpEnemyCastle = nodehpTroopCastle.NextSibling;
			XmlNode nodeTimeStart = nodehpEnemyCastle.NextSibling;
			XmlNode nodeTimeNextWave = nodeTimeStart.NextSibling;
			XmlNode nodetotalWave = nodeTimeNextWave.NextSibling;

			modeID = int.Parse (nodeModeID.InnerXml);
			hpTroopCastle = int.Parse (nodehpTroopCastle.InnerXml);
			hpEnemyCastle = int.Parse (nodehpEnemyCastle.InnerXml);
			timeStart = int.Parse (nodeTimeStart.InnerXml);
			timeNextWave = int.Parse (nodeTimeNextWave.InnerXml);
			totalWave = int.Parse (nodetotalWave.InnerXml);
		}

		string xmlPathLevelWave = xmlPathLevel + "/waves";
		XmlNodeList myNodeWaveList = xmlDoc.SelectNodes (xmlPathLevelWave);

		DataWave tempData = new DataWave();
		foreach(XmlNode node in myNodeWaveList)
		{
			XmlNode enemyType = node.FirstChild;
			XmlNode enemyLevel = enemyType.NextSibling;	
			XmlNode enemyNum = enemyLevel.NextSibling;
			XmlNode enemyLane = enemyNum.NextSibling;
			XmlNode timeNextEnemy = enemyLane.NextSibling;

			tempData.enemyType = int.Parse (enemyType.InnerXml);
			tempData.enemyLevel = int.Parse (enemyLevel.InnerXml);
			tempData.enemyNum = int.Parse (enemyNum.InnerXml);
			tempData.enemyLane = int.Parse (enemyLane.InnerXml);
			tempData.timeNextEnemy = float.Parse (timeNextEnemy.InnerXml);

			listWaves.Add (tempData);
		}
	}

}

public class DataWave 
{
	public int enemyType;
	public int enemyLevel;
	public int enemyNum;
	public int enemyLane;
	public float timeNextEnemy;
}
