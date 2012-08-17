// --- Event registration // Why do we put these at the top?

registerInputEvent(fxDTSBrick, "dayCycleOnDawn","Self fxDTSBrick\tMinigame Minigame");
registerInputEvent(fxDTSBrick, "dayCycleOnNoon","Self fxDTSBrick\tMinigame Minigame");
registerInputEvent(fxDTSBrick, "dayCycleOnDusk","Self fxDTSBrick\tMinigame Minigame");
registerInputEvent(fxDTSBrick, "dayCycleOnMidnight","Self fxDTSBrick\tMinigame Minigame");

// --- Events
// - I'm only gonna comment one of these, the others are all the same.
// - V8: Removed player and client targets - they aren't stable

function fxDTSBrick::dayCycleOnDawn(%this)
{
	$inputTarget_Self = %this; // %this is the brick that the event is called on.
	// $inputTarget_Player = ; // this defines the player as the player of the client of %this. //removed because useless and unclean - I can't do isObject checks on these safely.
	// $inputTarget_Client = %this.client; // this defines the client as the client of %this.
	// $inputTarget_Minigame = getMinigameFromObject(%this); // this defines the minigame as the minigame of the client of %this.
	%this.processInputEvent("dayCycleOnDawn", %this.client); // this causes the event to run. very important.
	DayCyclesDebug("Processing dawn on " @ %this);
}

function fxDTSBrick::dayCycleOnNoon(%this)
{
	$inputTarget_Self = %this;
	// $inputTarget_Player = %this.client.player;
	// $inputTarget_Client = %this.client;
	// $inputTarget_Minigame = getMinigameFromObject(%this);
	%this.processInputEvent("dayCycleOnNoon", %this.client);
	DayCyclesDebug("Processing noon on " @ %this);
}

function fxDTSBrick::dayCycleOnDusk(%this)
{
	$inputTarget_Self = %this;
	// $inputTarget_Player = %this.client.player;
	// $inputTarget_Client = %this.client;
	// $inputTarget_Minigame = getMinigameFromObject(%this);
	%this.processInputEvent("dayCycleOnDusk", %this.client);
	DayCyclesDebug("Processing dusk on " @ %this);
}

function fxDTSBrick::dayCycleOnMidnight(%this)
{
	$inputTarget_Self = %this;
	// $inputTarget_Player = %this.client.player;
	// $inputTarget_Client = %this.client;
	// $inputTarget_Minigame = getMinigameFromObject(%this);
	%this.processInputEvent("dayCycleOnMidnight", %this.client);
	DayCyclesDebug("Processing midnight on " @ %this);
}