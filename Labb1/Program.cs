using System.Threading.Channels;

namespace Labb1;

internal class Program
{
    private static void Main(string[] args)
    {

 Console.WriteLine("Välkommen till flygtidsberäknaren!");
        Console.WriteLine("Vilket flyg vill du se detaljerad information om? (svar med siffra)");

        var consoleRunning = true;
// Här använder vi en while-loop som körs tills användaren anger ett giltigt alternativ, det vill säga 1, 2 eller 3. 
// Om användaren anger ett ogiltigt alternativ, upprepas frågan om och om igen tills ett korrekt val görs!
        while (consoleRunning)
        {
            Console.WriteLine("1. Stockholm – New York");
            Console.WriteLine("2. New York – Stockholm");
            Console.WriteLine("3. Avsluta programmet!");
            Console.Write("Skriv ditt val här: ");

            // Ett enkelt try-catch-block som hanterar formatfel, det vill säga om användaren skriver in något som inte är en siffra!
            try
            {
                var choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
// Här anropas själva funktionen och skickar med all information som argument, som jag vill skriva ut. 
// Jag kan lika gärna använda detta för en resa från London till Oslo eller tvärtom, så länge rätt data anges
                        DisplayFlightInfo("Stockholm", "New York", 14, 03, 7, 25, 6);
                        Console.WriteLine("Ha en trevlig resa!");
                        // Här avbryts loopen eftersom valet i case 1 är ett giltigt alternativ.
                        consoleRunning = false;
                        break;
                    case 2:
                        DisplayFlightInfo("New York", "Stockholm", 10, 10, 7, 25, 6);
                        Console.WriteLine("Ha en trevlig resa!");
                        consoleRunning = false;
                        break;
                    case 3:
                        Console.WriteLine("Programmet är avslutat, hejdå!");
                        consoleRunning = false;
                        break;
                    default:
                        Console.WriteLine("Alternativen måste var ett av de här: ");
                        break;
                }
            }
// Här fångar catch-blocket upp inmatningar som inte är siffror och skickar ett passande felmeddelande.
            catch (FormatException)
            {
                Console.WriteLine("Tecken eller bokstav kan inte tas emot, var vänlig och välj ett utav de här!");
            }
        }
    }

    // Här har jag skapat en funktion som tar emot sju parametrar. Dessa parametrar kan skickas som argument när funktionen anropas.
    //  Funktionen är generell och flexibel, vilket gör att den kan användas för flera olika destinationer och tidpunkter.
    // Den är inte begränsad till enbart Stockholm–New York eller vice versa, utan kan anpassas för andra resmål.
    private static void DisplayFlightInfo(string depatureCity, string arivalCity, int depatureHour, int depatureMin,
        int flightHours, int flightMins, int timeDifference)
    {
        var landingHour = depatureHour + flightHours + timeDifference;
        var landingMin = depatureMin + flightMins;


        if (landingMin >= 60)
        {
            landingHour += landingMin / 60;
            landingMin %= 60; // Om 70 min modulo 60 är väl 10 som är resten kommer att visas kvar här!
        }

        //Om timmarna överstiger 24 timmar då nollställs det här exempelvis 27 - 24 = 3 som motsvarar kl: 03:00
        landingHour %= 24; 
        Console.WriteLine($"Avgångstiden från {depatureCity}: {depatureHour}:{depatureMin.ToString("00")}");
        Console.WriteLine($"Ankomstiden till {arivalCity}: {landingHour.ToString("00")}:{landingMin.ToString("00")}");
    }

}
