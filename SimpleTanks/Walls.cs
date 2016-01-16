using System;
using TankAILib;

namespace TankAI.SimpleTanks
{
	/// <summary>
	/// Sample tank that follows the walls
	/// </summary>
	public class Walls : Tank
	{			
		private int ticksToWall;

		public Walls(NewTankArgs e): base(e)
		{				
			TurnGunWithTank = false;
			TurnLeft(0);
			TurnGunLeft(90);			
			ticksToWall = -1;
		}		

		public override void HitWall()
		{			
			TurnLeft((int)((Heading + 90) / 90) * 90);
			ticksToWall = (int)(Time + Math.Max(BattleFieldWidth, BattleFieldHeight) / 8 - 10);
		}

		public override void Tick()
		{
			if (Time == ticksToWall)
			{
                TurnLeft((int)((Heading + 90) / 90) * 90);
				ticksToWall = (int)(Time + Math.Max(BattleFieldWidth, BattleFieldHeight) / 8 - 16);
			}
		}

		public override void HitTank(HitTankArgs e)
		{
			TurnLeft((int)((Heading + 90) / 90) * 90);
			ticksToWall = -1;
		}

		public override void CompletedTurn()
		{
			TurnGunWithTank = true;			
			Forward();
		}

		public override void ScannedTank(TankArgs e)
		{
			Fire(1);
		}

	}
}
