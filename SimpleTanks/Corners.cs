using System;
using TankAILib;

namespace TankAI.SimpleTanks
{
	/// <summary>
	/// Sample tank that shots from a corner of the map
	/// </summary>
	public class Corners : Tank
	{
		// Keep track of which direction I need to turn the gun.  -1 represents clockwise and 1 represents counter-clockwise
		public int gunDirection;
		public int hitWallCount;

		public Corners(NewTankArgs e): base(e)
		{
			// Initialize tank settings.
			hitWallCount = 0;
			gunDirection = 1;			
			TurnGunLeft(Heading + 90);
			TurnGunWithTank = false;
			TurnRight((int)(Heading / 90) * 90);			
		}

		public override void HitWall()
		{
			// When I hit a wall, turn 90 degree and head toward the corner.
			hitWallCount++;
			if (hitWallCount < 2)
			{
				TurnLeft(Heading + 90);				
			}
		}

		public override void HitTank(HitTankArgs e)
		{
			// If I hit a tank along the way, just push onward until I reach the corner.
			Forward();
		}

		public override void CompletedTurn()
		{
			// After I hit my first wall and turn 90 degrees, move forward until I hit the corner
			Forward();
		}

		public override void CompletedGunTurn()
		{
			// Turn gun back and forth relative to tank, from 90 degrees to 180 degrees.
			gunDirection *= -1;
			if (gunDirection == 1)
			{
				TurnGunLeft(Heading + 180);
			}
			else
			{
				TurnGunRight(Heading + 90);
			}
		}

		public override void ScannedTank(TankArgs e)
		{			
			Fire(1);
		}
	}
}
