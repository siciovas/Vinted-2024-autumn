using VintedBackend;
using VintedBackend.Rules;

var lines = FileService.ReadLinesFromFile();

var rules = new RulesBuilder();

var discountCalculation = new DiscountCalculation();

rules.RuleRegistration(new FirstRule());
rules.RuleRegistration(new SecondRule());

foreach (var line in lines)
{
    var shipment = FileService.ParseLines(line);

    if (shipment != null)
    {

        discountCalculation.ValidateShipment(shipment);

        rules.RuleApplication(shipment, discountCalculation);

        Console.WriteLine(shipment.FormatLines());
    }
}

