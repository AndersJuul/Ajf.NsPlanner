# Ajf.NsPlanner
Program til hjælp for planlægning af arrangementer i Slagelse Naturskole, https://naturskole.slagelse.dk/.
Programmet er open source og må kopieres i sin helhed eller blot i de dele, der kan bruges med nytte.

Programmet vedligeholder en database indeholdende personhenførbare oplysninger (Navn, Email og Telefon på ønskeindsender), men da det indskærpes på indtastningsformularen at kun arbejdsmail og arbejdstelefon må anvendes, er opbevaring af disse oplysninger meget lidt kritisk. Vi har alligevel forsøgt at indarbejde kode og procedurer til opfyldelse af GDPR.

Programmet er inspireret af konstruktioner fra Steve Smith (https://ardalis.com), Vladimir Khorikov (https://enterprisecraftsmanship.com/) og Eric Evans (http://domainlanguage.com/)

## Actors

### Tildeler

Den person som arbejder med at behandle ønsker og afgøre om de skal tildeles et arrangement eller have afslag.

### GDPR-ansvarlig

Den person som sikrer at GDPR overholdes gennem sletning af personhenførbare oplysninger, når opbevaring af dem ikke længere er relevant.

### Backup-ansvarlig

Den person som sikrer at der tages backup af programmets data, primært filerne indeholdende databasen i Microsoft SQL Server-format.

## Use Cases

### Indlæsning af ønsker

Som tildeler ønsker jeg at kunne indlæse en csv-fil med ønsker, som feks den som idag kan opdateres fra indtastningsformularen på google drive. 

Ved indlæsning skal perioder oprettes efter behov, hvis de ligger i fremtiden. Ønsker som vedrører fortiden vil blive ignoreret.

### Oprydning af ønsker

Som GDPR-ansvarlig ønsker jeg at alle ønsker (med Navn, Email og Telefonnummer) fjernes fra systemet når en Periode slettes. Bemærk at dette er en manuel process.

### Visning af ønsker
Som tildeler ønsker jeg at kunne se en oversigt over indsendte ønsker og deres evt tildeling. Ønsker med evt tildeling skal kunne sortere efter :

* Tidspunkt for oprettelse af ønske
* Navn på institution

### Markering af ønsker
Som tildeler ønsker jeg at kunne sætte 'mærker' på enkelte ønsker for at markere intentionen med dem -- skal de have julearrangement, er de tidligere sæsoner blevet forfordelt eller anden markering.
### Filtrering af ønsker

Som tildeler ønsker jeg at kunne filtrere ønsker således at kun et sub-set af ønskerne vises. Der skal kunne filtereres på rækker på basis af tildelingsstatus, mærker og ønsket arrangement

### Sletning af perioder

Som GDPR-ansvarlig ønsker jeg at kunne slette en periode, således at alle registrerede ønsker og arrangementer slettes fra databasen for den pågældende periode. Bemærk, at man ved indlæsning af ønsker vil oprette perioden igen hvis den ligger i fremtiden, men ikke hvis den ligger i fortiden (som det ofte vil være tilfældet).

### Backup og sletning af programoplysninger

Som Backup-ansvarlig og som GDPR-ansvarlig ønsker jeg alle programmets data opbevaret i en separat folder, der kan laves backup af eller slettes.

*By design*: Programmets database, hvori der vil være personhenførbare oplysninger, ligger i c:\programdata\NsPlanner. Tilstandsfil, som beskriver hvilke tilstand for vinduer ved sidste programafvikling ligger også i denne folder. 

Csv-filer med følsomme data kan med fordel lægges samme sted, men det er udenfor programmets indflydelse hvortil de downloades og indlæses fra.

## Ubiquitous Language (nouns, engelske gloser er benævnelsen i koden)
### Ønske (EventRequest)

Ønsket er som indtastet af indsendere af ønsket: Hvem man er, hvad man ønsker og hvornår.

### Arrangement (SchoolEvent)

Et af de arrangementer, som Naturskolen faktisk udbyder. Når der tildeles et arrangement kan Tildeler vælge præcis det ønskede arrangement eller et alternativ, som det vurderes hensigtsmæssigt. Alle tildelinger skal have et Arrangement knyttet til sig for at være Fuldt Specificeret.

### Naturvejleder (Counselor)

En af de naturvejledere som er tilknyttet Naturskolen, fast eller løst. Alle tildelinger skal have en Naturvejleder knyttet til sig for at være Fuld Specificeret.

### Tildeling (Assignment)
### Sted (Place)

Et af de steder, som arrangementer afholdes. Alle tildelinger skal have et sted knyttet til sig for at være Fuld Specificeret.

### Afholdelsestidspunkt ()

Dato, starttid og sluttid. Alle tildelinger skal have et Afholdelsestidspunkt knyttet til sig for at være Fuld Specificeret.

### Tildeler
Den person, der bruger programmet til at fordele arrangementer mellem indsendere af ønsker

### Indsendere af ønsker

De personer, som feks via Google indtastningsformular har indsendt et ønsker om et arrangement med Naturskolen.

### Mærke (Marker)

Et simpelt mærke som kan sættes på et ønske og derefter bruges til at filtere ønsker efter. Eksempelvis kan man markere alle julearrangementer med '0' og alle arrangementer som kræver sensommervejr med et '1' og derefter filtrere så kun '0' og '1' vises.

## Ubiquitous Language (verbs, engelske gloser er benævnelsen i koden)
### Tildele arrangement
At knytte en Naturvejleder, et Sted og et Arrangement og et Afholdelsestidspunkt til et Ønske.

### Slette en periode

Handlingen, når man ønsker at fjerne alle registreringer for en periode. Alle ønsker og tildelinger fjernes når en periode slettes.

## GDPR

Ønsker og tildelinger gemmes i databasen og opbevares indtil de aktivt slettes ved lukning af en periode. En periode vil normalt holdes åben indtil ønsker er behandlet for den efterfølgende periode.

Eksempelvis vil en tildeler i sommeren 2019 behandle ønsker for efteråret 2019. Tildeleren vil i vinteren 2019/2020 tildele behandle ønsker for foråret 2020. Når der er udsendt mails om tildelte arrangementer for foråret 2020 vil tildeleren slette perioden 'efterår 2019' hvorved alle registreringer i databasen slettes for denne periode.