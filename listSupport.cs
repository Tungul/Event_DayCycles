// --- List Support functions. Ask Mold, I don't know.
// - Todo: Comment this. It's a very useful resource.

//List functions found in Event_Minigame

function addItemToList(%string, %item)
{
	if(hasItemOnList(%string, %item))
		return %string;

	if(%string $= "")
		return %item;
	else
		return %string SPC %item;
}

function hasItemOnList(%string,  %item)
{
	for(%i=0;%i<getWordCount(%string);%i++)
	{
		if(getWord(%string, %i) $= %item)
			return 1;
	}
	return 0;
}

function removeItemFromList(%string, %item)
{
	if(!hasItemOnList(%string, %item))
		return %string;

	for(%i=0;%i<getWordCount(%string);%i++)
	{
		if(getWord(%string, %i) $= %item)
		{
			if(%i $= 0)
				return getWords(%string, 1, getWordCount(%string));
			else if(%i $= getWordCount(%string)-1)
				return getWords(%string, 0, %i-1);
			else
				return getWords(%string, 0, %i-1) SPC getWords(%string, %i+1, getWordCount(%string));
		}
	}
}

function doEventsByList(%mode)
{

	DayCyclesDebug("Processing events...");
	for(%i = 0; %i < getWordCount($DayCycleBrickList); %i++)
	{
		%b = getWord($DayCycleBrickList, %i);
		
		if(!isObject(%b))
		{
			$DayCycleBrickList = removeItemFromList($DayCycleBrickList, %b);
			continue;
		}

		switch$(%mode)
		{
			case "Dawn":
				%b.dayCycleOnDawn();
			case "Noon":
				%b.dayCycleOnNoon();
			case "Dusk":
				%b.dayCycleOnDusk();
			case "Midnight":
				%b.dayCycleOnMidnight();
		}

		DayCyclesDebug("Events processed on:" SPC %b);
	}
}