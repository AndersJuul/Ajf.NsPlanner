# Ajf.NsPlanner
Program til hjælp for planlægning af arrangementer i Slagelse Naturskole, https://naturskole.slagelse.dk/.
Programmet er open source og må kopieres i sin helhed eller blot i de dele, der kan bruges med nytte.

Programmet er inspireret af konstruktioner fra Steve Smith (https://ardalis.com), Vladimir Khorikov (https://enterprisecraftsmanship.com/) og Eric Evans (http://domainlanguage.com/)

## Use Cases
### Visning af ønsker
Som tildeler ønsker jeg at kunne se en oversigt over indsendte ønsker og kunne sortere efter kolonner
### Filtrering af ønsker
Som tildeler ønsker jeg at kunne filtrere ønsker således at kun et sub-set af ønskerne vises

## Ubiquitous Language (nouns)
### Ønske (EventRequest)
### Arrangement (SchoolEvent)
### Naturvejleder (Counselor)
### Tildeling (Assignment)
### Sted (Place)
### Afholdelsestidspunk ()
### Tildeler
Den person, der bruger programmet til at tildele arrangemener til [requestor]
## Ubiquitous Language (verbs)
### Tildele arrangement
At knytte en Naturvejleder, et Sted og et Arrangement og et Afholdelsestidspunkt til et Ønske.
