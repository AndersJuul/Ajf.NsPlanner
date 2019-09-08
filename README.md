# Ajf.NsPlanner
Program til hjælp for planlægning af arrangementer i Slagelse Naturskole, https://naturskole.slagelse.dk/.
Programmet er open source og må kopieres i sin helhed eller blot i de dele, der kan bruges med nytte.

Programmet er inspireret af konstruktioner fra Steve Smith (https://ardalis.com), Vladimir Khorikov (https://enterprisecraftsmanship.com/) og Eric Evans (http://domainlanguage.com/)

## Use Cases
### Indlæsning af ønsker
Som tildeler ønsker jeg at kunne indlæse en csv-fil med ønsker, som feks den som idag kan opdateres fra indtastningsformularen på google drive.
### Visning af ønsker
Som tildeler ønsker jeg at kunne se en oversigt over indsendte ønsker og kunne sortere efter kolonner
### Markering af ønsker
Som tildeler ønsker jeg at kunne sætte 'mærker' på enkelte ønsker for at markere intentionen med dem -- skal de have julearrangement, er de tidligere sæsoner blevet forfordelt eller anden markering.
### Filtrering af ønsker
Som tildeler ønsker jeg at kunne filtrere ønsker således at kun et sub-set af ønskerne vises. Der skal kunne filtereres på rækker på basis af tildelingsstatus, mærker og ønsket arrangement

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

