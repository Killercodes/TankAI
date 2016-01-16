using System;
using TankAILib;

namespace TankAI.SimpleTanks
{
	/// <summary>
	/// Sample tank that tracks the movement of its target and moves in for the kill
	/// </summary>
	public class Track : Tank
	{	
		private bool scannedEnemy;

		public Track(NewTankArgs e): base(e)
		{			
			TurnScannerWithGun = false;			
			scannedEnemy = false;			
		}

		public override void Tick()
		{
			if (scannedEnemy)
			{
				TurnScannerLeft(ScannerHeading + 10);
			}
			else
			{
				TurnScannerRight(ScannerHeading - 5);
			}
			scannedEnemy = false;
		}		

		public override void ScannedTank(TankArgs e)
		{
			Fire(1);

			scannedEnemy = true;
			TurnScannerLeft(ScannerHeading + 10);				

			double newHeading = e.Bearing;

			if ((newHeading - Heading + 360) % 360 < 180)
			{
				TurnLeft(newHeading);
			}
			else
			{
				TurnRight(newHeading);
			}				

			if (e.Distance > 200)
			{
				Forward();
			}
			else
			{
				Stop();
			}
		}		
	}
}
