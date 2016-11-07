#Lab - Internal Messaging

**Tid:** 10-30 minuter

**Område:** Pub/sub

**Genomgång:** En snabb genomgång av vad Internal Messaging innebär, vilka problem det löser samt vilka varianter av färdiga ramverk som finns tillgängliga.

**Miljö:**

* Xamarin Forms (inte ett krav)
* TinyPubSub (enkel implementation av Pub/Sub)

**Förkunskaper**

* Grundläggande MVVM
* Grundläggande IoC

##Syfte med labben
Att tillhandahålla grundläggande kunskaper i hur man kan lösa intern meddelandehantering i en app för att koppla lös beroenden.

##Förberedande arbete

### Klona miljön
```
git clone https://github.com/dhindrik/TDswe16.git
```

### Öppna solution filen
Öppna solution filen i **Visual Studio** eller i **Xamarin studio**.

```
/TDSwe16/Lab - Internal Messaging/lab/InternalMessaging.sln
```

Om man skulle köra fast eller bara vill fuska lite så finns det en katalog som heter ```solution``` där man kan titta på hur det skulle ha blivit.

## Modul 1 - Identifiera problemet
TODO






#API
Detta är referensmaterial för det API vi har satt upp för labben.

##api/orders
Hanterar arbetsbeskrivningar

```
GET
/api/orders?repairState=pending&bookedMechanicSignature=BvF

/api/orders/{id}

POST
/api/orders

{
   "id" : "",
   "registrationNumber" : "ABC123",
   "description" : "Framhjulet har ramlat av, sätt fast det igen",
   "estimate": "1950 kr",
   "repairState" : "pending",
   "invoiceState" : "notsent",
   "bookedTime" : "2016-10-11T13:00",
   "bookedMechanicSignature" : "BvF",
   "bookedMechanicFullName" : "Bob von Fippelton"
}

PUT 
/api/orders/{id}

DELETE
/api/orders/{id}

```

##api/estimate
Hanterar förfrågningar för reparation

```
POST
/api/estimate

{
	"typeOfService":"intervalService",
	"brand":"Volvo",
	"model":"S40",
	"milage":"30000",
	"description":"En helt vanlig service med extra ost"
}
		

```