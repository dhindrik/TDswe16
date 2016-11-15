#Lab - Xamarin.Android

**Tid:** 60 minuter

**Område:** Android


**Miljö:**

* Mac med Xamarin Studio eller PC med Visual Studio

##Syfte med labben
Att tillhandahålla grundläggande kunskaper för att komma igång att utveckla Android-appar med Xamarin

##Förberedande arbete

### Klona miljön
```
git clone https://github.com/dhindrik/TDswe16.git
```

### Öppna solution filen
Öppna solution filen i **Visual Studio** eller i **Xamarin studio**.

```
/TDSwe16/Lab - Xamarin.Android/lab/Xamarin.Android.sln
```

Om man skulle köra fast eller bara vill fuska lite så finns det en katalog som heter ```solution``` där man kan titta på hur det skulle ha blivit.

##Instruktioner
1.	Starta Visual Studio eller Xamarin Studio.

	```xml
	<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
5. En activity kan man säga att motsvarar en sida i en Android app. När vi skapar ett projekt har vi fått en MainActivity skapad åt oss. Öppna MainActivity.cs och läs in gränssnittet vi skapade med hjälp av SetContentView-metoden. Detta ska göras i OnCreate.
	
	```csharp
	protected override void OnCreate(Bundle bundle)
  ```
6. För att ändra sidans rubrik ändrar vi Label-egenskapen i Activity attributet so ligger på klassnivå i MainActivity.
7. För att kunna hantera knappen vi skapade i Main.axml måste vi läsa in den. Det gör vi med hjälp av det id vi satte på knappen. När vi har läst in knappen kan vi koppla en eventhanterare till Click-eventet.

	```csharp
	var button = FindViewById<Button>(Resource.Id.LetsGo);
	```
	```csharp
	private void Button_Click(object sender, System.EventArgs e)
   ```
8. Skapa en ny activity med namnet CreateUserActivity.
9. I eventlyssnaren för knappen i MainActivity lägger vi till att vi vill navigera till CreateUserActivity.
	
	```csharp
private void Button_Click(object sender, System.EventArgs e)
   ```
10.  Skapa en ny "Android Layout" i layouts katalogen under Resources, ge den namnet CreateUser. Inuti den LinearLayout som finns där skapar vi två inputfält och en knapp.

	```xml
	<EditText
    ```
11. I CreateActivity skapa en eventhanterare och koppla den till Saveknappen som vi gjorde i ett tidigare steg. I eventhanterare vill vi visa en dialogruta med värden från inputfälten och när man klickar på "OK" vill vi navigera till en ny activity. Därför skapar vi en activity med namnet NewsActivity.

	```csharp
	var firstname = FindViewById<EditText>(Resource.Id.firstname);
    alert.Show();
    ``` 
12. Kör applikationen.
13. Ändra arvet på NewsActivity till att ärva från ListActivity istället för Activity. Detta kan vi göra när vi vill att hela sidan ska vara en lista.
14. Alla listor i Android behöver en Adapter för att populera data. Därför skapar vi en ny adapter som vi kallar för NewsAdapter. Adaptern ska ärva från BaseAdapter och vi implementerar alla abstrakta metoder från BaseAdapter.
	
	```csharp
public class NewsAdapter : BaseAdapter
    ```
15. Vi kommer senare att behöva komma åt activityn som listan ligger i, därför skapar vi en privat variabel av typen Activity och en konstuktor som tar emot en Activity och sätter den privata variablen. 

	```csharp
	private Activity _activity;
    ```
16. För att få lite mockdata, kopiera in koden nedan i konstruktorn och skapa en privat variabel för listan med mockdata.

	```csharp
	_items = new List<Tuple<string, string>>();
   ```
17. Nu vill vi skapa en layout för varje rad i listan. Skapa en ny "Android Layout" i Layout katalogen med namnet "NewsItem". I den lägg till ett TextField för rubrik och ett TextField för text.
18. I adaptern låt GetItemId returna 0 eftersom vi inte har något id i vår mock.
19. Count propertyn ska returnera antalet items i listan.

	```csharp
	public override int Count
    ```
20. GetView är den metod som skapar en vy som ska visas för varje rad i listan. För att läsa in den layout vi skapade med xml använder vi oss av LayoutInflater som är en egenskap på activity. När vi sedan läst in den vyn kan vi sätta värde på textfälten från listan baserat på den position som vi får som argument till GetView-metoden.
	
	```csharp
	var view = _activity.LayoutInflater.Inflate(Resource.Layout.NewsItem, null);
  ```

	```csharp
	protected override void OnCreate(Bundle savedInstanceState)
	```
22. Kör applikationen.