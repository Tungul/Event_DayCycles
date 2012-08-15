// --- Package

//This package allows:
//- Starting and stopping the time tick
//- Nabbing events as they are added and adding them to an array

package dayCycleTime
{
	function serverCmdEnvGui_SetVar(%client, %variable, %value) // Client that triggered, variable modified, new value
	{
		if(%variable $= "DayCycleEnabled") //Unfortunately, it doesn't work properly.
		{
			if(%value) //if the boolean in %value is true...
			{
				$DayCycles::Enabled = 1;
				startDayCycleTimeTick(); //start.
				DayCyclesDebug("Starting DayCycle TimeTick at length:" SPC DayCycle.dayLength);
			}
			else //if the boolean in %value is false...
			{
				$DayCycles::Enabled = 0; //as of V7 this will actually have the right number in it. why the hell was there a 2 here?
				stopDayCycleTimeTick(); //stop.
				DayCyclesDebug("Stopping DayCycle TimeTick.");
			}
		}
		
		if(%variable $= "DayLength" && $DayCycles::Enabled) //catch when the nooby client goes and changes the time on us.
		{
			startDayCycleTimeTick(); //not starting, updating.
			DayCyclesDebug("Updating DayCycle TimeTick with new length:" SPC %value);
		}

		return parent::serverCmdEnvGui_SetVar(%client, %variable, %value);
	}

	//everything pertaining to events in this package is credit to Mold. Thanks Mold!
	//We have to add the brick to list when the event is added to a brick
	function serverCmdAddEvent(%client, %delay, %input, %target, %a, %b, %output, %par1, %par2, %par3, %par4)
	{
		%i1 = inputEvent_GetInputEventIdx("dayCycleOnDawn"); // Forgot to change these in V6. Oops.
		%i2 = inputEvent_GetInputEventIdx("dayCycleOnNoon");
		%i3 = inputEvent_GetInputEventIdx("dayCycleOnDusk");
		%i4 = inputEvent_GetInputEventIdx("dayCycleOnMidnight");

		if(%input == %i1 || %input == %i2 || %input == %i3 || %input == %i4) // Made it nicer just for Mold.
		{
			$DayCycleBrickList = addItemToList($DayCycleBrickList, %client.wrenchBrick);
			DayCyclesDebug("Adding brick to event list:" @ %client.wrenchBrick);
		}

		return parent::serverCmdAddEvent(%client, %delay, %input, %target, %a, %b, %output, %par1, %par2, %par3, %par4);
	}
	//We have to remove the brick from list when the event is removed from a brick 

	function serverCmdClearEvents(%client)
	{
		if(hasItemOnList($DayCycleBrickList, %client.wrenchBrick))
		{
			$DayCycleBrickList = removeItemFromList($DayCycleBrickList, %client.wrenchBrick);
			DayCyclesDebug("Removing brick from event list:" @ %client.wrenchBrick);
		}

		parent::serverCmdClearEvents(%client);
	}

	function fxDtsBrick::onDeath(%brick)
	{
		if(hasItemOnList($DayCycleBrickList, %brick))
		{
			$DayCycleBrickList = removeItemFromList($DayCycleBrickList, %brick);
			DayCyclesDebug("Removing brick from event list:" @ %brick);
		}

		parent::onDeath(%brick);
	}
	//everything pertaining to events in this package is credit to Mold.
	
	function serverCmdClearAllBricks(%client) // Mold forgot this one. I should tell him about it for his event cmds.
	{
		parent::serverCmdClearAllBricks(%client);

		DayCyclesDebug("Removing all bricks from list.");

		$DayCycleBrickList = "";
	}
};
activatePackage("dayCycleTime");