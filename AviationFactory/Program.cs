using AviationFactory.Extensions;

var militaryFacility = DataInitialization.InitializePersonnelAndFacility("Mil");
var civilFacility = DataInitialization.InitializePersonnelAndFacility("Civil");
var cargoFacility = DataInitialization.InitializePersonnelAndFacility("Cargo");


Console.WriteLine(militaryFacility);