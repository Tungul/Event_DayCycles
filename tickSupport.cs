// --- Tick Support

function startDayCycleTimeTick() //Starts/updates the schedule loop.
{
	if(!isObject(DayCycle)) //Check if DayCycle exists (it probably will.)
		return;

	dayCycleTimeTickLoop(1);
}

function stopDayCycleTimeTick() //Stops the schedule loop.
{
	if(!isObject(DayCycle)) //Check if DayCycle exists (it probably will.)
		return;

	dayCycleTimeTickLoop(0);
}

function dayCycleTimeTickLoop(%on) //This is the almighty loop function.
{
	cancel(DayCycle.timeTick); //Stop the tick. This is for when you might manually restart or update the tick, so you don't end up with two ticks.

	if(!isObject(DayCycle)) //Check if DayCycle exists (it probably will.)
		return;

	if(!%on) //If we're supposed to stop, then stop.
		return;

	%part = getPartOfDayCycle(); //Determine what part of day it is.

	DayCycle.timeOfDay = getDayCycleTime(); //Determine what time of day it is.

	// centerPrintAll("\c6Time:\c3" SPC DayCycle.timeOfDay SPC %part, 1); //For debugging purposes. //V2: Sorry guys, forgot to take this out lol.

	switch(%part) //Check the partofday number against a list.
	{
		case 0:
			onDawn();
		case 1:
			onNoon();
		case 2:
			onDusk();
		case 3:
			onMidnight();
	}

	DayCycle.timeTick = schedule(getNextDayCycleTime(), 0, dayCycleTimeTickLoop, 1); //reschedule the loop
}
