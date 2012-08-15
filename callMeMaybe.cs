// --- Callback functions // For modders

function onDawn(%this)
{
	doEventsByList("Dawn");
	DayCyclesDebug("It is now day.");
}

function onNoon(%this)
{
	doEventsByList("Noon");
	DayCyclesDebug("It is now noon.");
}

function onDusk()
{
	doEventsByList("Dusk");
	DayCyclesDebug("It is now night.");
}

function onMidnight()
{
	doEventsByList("Midnight");
	DayCyclesDebug("It is now midnight.");
}
