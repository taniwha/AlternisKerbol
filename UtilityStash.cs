//This file contains a bunch of reference functions that I used to help decipher how things work. Feel free to use them to help with your own mods, no need to ask for permission.

/*

*******************************************************************************************
This function returns all the science info for all celestialbodies, for reference purposes.
  
string science = "Planet science values are as follows... \n";
foreach (CelestialBody cb in FlightGlobals.Bodies)
{
    string s = cb.gameObject.name +":\n";
    s += "Landed: " + cb.scienceValues.LandedDataValue + "\n";
    s += "Splashed: " + cb.scienceValues.SplashedDataValue + "\n";
    s += "Atmosphere, low: " + cb.scienceValues.FlyingLowDataValue + "\n";
    s += "Atmosphere, high: " + cb.scienceValues.FlyingHighDataValue + "\n";
    s += "Atmosphere threshold: " + cb.scienceValues.flyingAltitudeThreshold + "\n";
    s += "Space, low: " + cb.scienceValues.InSpaceLowDataValue + "\n";
    s += "Space, high: " + cb.scienceValues.InSpaceHighDataValue + "\n";
    s += "Space threshold: " + cb.scienceValues.spaceAltitudeThreshold + "\n";
    s += "Recovery: " + cb.scienceValues.RecoveryValue + "\n \n";
    science += s;
}

print(science);

*******************************************************************************************
This one spits out all components of a given gameobject...

GameObject desired_gameobject = whatever;
string s = "Listing all components! \n";
foreach (Component c in desired_gameobject.GetComponentsInChildren(typeof(Component)))
{
    s += (c + " \n");
}
print(s);

*******************************************************************************************
Biome info dumper

string biome = "Reporting biome data! \n";
foreach (CBAttributeMap.MapAttribute mb in celestialbody.BiomeMap.Attributes)
{
    biome += mb.name + "\n";
    biome += mb.mapColor + "\n";
    biome += mb.value + "\n";
}
print(biome);
*/