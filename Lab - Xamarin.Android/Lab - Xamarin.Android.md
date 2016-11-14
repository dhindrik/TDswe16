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
1.	Starta Visual Studio eller Xamarin Studio.2.	Skapa ett nytt projekt3.	Välj ”Blank App” under Android.4.	I katalogen Layouts under Resources finns en fil med namnet Main.axml. Det är den xml fil som är tänkt för att skapa gränssnittet för den första sidan i appen. Från start ligger det en LinearLayout i den. Det är en layout som lägger UI-komponenter efter varandra. Inuti layouten ska vi skapa en knapp. Vi sätter layout_width till ```fill_parent``` eftersom vi vill att knappen ska fylla hela appens bredd. På layouten lägger vi också till 10 dp med padding. dp är en enhet för att hantera olika skärmars upplösningar.

	```xml
	<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"    android:orientation="vertical"    android:layout_width="match_parent"    android:layout_height="match_parent"		android:padding="10dp">	<Button        android:id="@+id/LetsGo"        android:layout_width="fill_parent"        android:layout_height="wrap_content"        android:text="Lets go" /></LinearLayout>```
5. En activity kan man säga att motsvarar en sida i en Android app. När vi skapar ett projekt har vi fått en MainActivity skapad åt oss. Öppna MainActivity.cs och läs in gränssnittet vi skapade med hjälp av SetContentView-metoden. Detta ska göras i OnCreate.
	
	```csharp
	protected override void OnCreate(Bundle bundle)   {            base.OnCreate(bundle);            // Set our view from the "main" layout resource            SetContentView (Resource.Layout.Main);    }
  ```
6. För att ändra sidans rubrik ändrar vi Label-egenskapen i Activity attributet so ligger på klassnivå i MainActivity.
7. För att kunna hantera knappen vi skapade i Main.axml måste vi läsa in den. Det gör vi med hjälp av det id vi satte på knappen. När vi har läst in knappen kan vi koppla en eventhanterare till Click-eventet.

	```csharp
	var button = FindViewById<Button>(Resource.Id.LetsGo);button.Click += Button_Click;
	```
	```csharp
	private void Button_Click(object sender, System.EventArgs e)    {                }
   ```
8. Skapa en ny activity med namnet CreateUserActivity.
9. I eventlyssnaren för knappen i MainActivity lägger vi till att vi vill navigera till CreateUserActivity.
	
	```csharp
private void Button_Click(object sender, System.EventArgs e)   {        StartActivity(typeof(CreateUserActivity));   }
   ```
10.  Skapa en ny "Android Layout" i layouts katalogen under Resources, ge den namnet CreateUser. Inuti den LinearLayout som finns där skapar vi två inputfält och en knapp.

	```xml
	<EditText		android:id="@+id/firstname"		android:layout_width="fill_parent"		android:layout_height="wrap_content"		android:hint="Firstname" />		<EditText		android:id="@+id/lastname"		android:layout_width="fill_parent"		android:layout_height="wrap_content"		android:hint="Lastname" />	<Button        android:id="@+id/Save"        android:layout_width="fill_parent"        android:layout_height="wrap_content"        android:text="Save" />
    ```
11. I CreateActivity skapa en eventhanterare och koppla den till Saveknappen som vi gjorde i ett tidigare steg. I eventhanterare vill vi visa en dialogruta med värden från inputfälten och när man klickar på "OK" vill vi navigera till en ny activity. Därför skapar vi en activity med namnet NewsActivity.

	```csharp
	var firstname = FindViewById<EditText>(Resource.Id.firstname);   var lastname = FindViewById<EditText>(Resource.Id.lastname);  var alert = new AlertDialog.Builder(this);  alert.SetTitle("Hi " + firstname.Text + " " + lastname.Text + "!");  alert.SetNeutralButton("OK", (s, args) =>  {       	StartActivity(typeof(NewsActivity));  });            
    alert.Show();
    ``` 
12. Kör applikationen.
13. Ändra arvet på NewsActivity till att ärva från ListActivity istället för Activity. Detta kan vi göra när vi vill att hela sidan ska vara en lista.
14. Alla listor i Android behöver en Adapter för att populera data. Därför skapar vi en ny adapter som vi kallar för NewsAdapter. Adaptern ska ärva från BaseAdapter och vi implementerar alla abstrakta metoder från BaseAdapter.
	
	```csharp
public class NewsAdapter : BaseAdapter    {        public override int Count        {            get            {                throw new NotImplementedException();            }        }        public override Java.Lang.Object GetItem(int position)        {            throw new NotImplementedException();        }        public override long GetItemId(int position)        {            throw new NotImplementedException();        }        public override View GetView(int position, View convertView, ViewGroup parent)        {            throw new NotImplementedException();        }    }
    ```
15. Vi kommer senare att behöva komma åt activityn som listan ligger i, därför skapar vi en privat variabel av typen Activity och en konstuktor som tar emot en Activity och sätter den privata variablen. 

	```csharp
	private Activity _activity;    public NewsAdapter(Activity activity)    {            _activity = activity;    }
    ```
16. För att få lite mockdata, kopiera in koden nedan i konstruktorn och skapa en privat variabel för listan med mockdata.

	```csharp
	_items = new List<Tuple<string, string>>();   _items.Add(new Tuple<string, string>("Microsoft köper Xamarin", "Nu är det klart att Microsoft köper det San Francisco baserade företaget Xamarin"));   _items.Add(new Tuple<string, string>("Xamarin = native", "Xamarin är native"));   _items.Add(new Tuple<string, string>("TechDays", "Microsoft TechDays är den 15-17 november"));   _items.Add(new Tuple<string, string>("Xamarin är gratis", "Xamarin är nu gratis för alla"));
   ```
17. Nu vill vi skapa en layout för varje rad i listan. Skapa en ny "Android Layout" i Layout katalogen med namnet "NewsItem". I den lägg till ett TextField för rubrik och ett TextField för text.
18. I adaptern låt GetItemId returna 0 eftersom vi inte har något id i vår mock.
19. Count propertyn ska returnera antalet items i listan.

	```csharp
	public override int Count   {            get            {                return _items.Count;            }    }
    ```
20. GetView är den metod som skapar en vy som ska visas för varje rad i listan. För att läsa in den layout vi skapade med xml använder vi oss av LayoutInflater som är en egenskap på activity. När vi sedan läst in den vyn kan vi sätta värde på textfälten från listan baserat på den position som vi får som argument till GetView-metoden.
	
	```csharp
	var view = _activity.LayoutInflater.Inflate(Resource.Layout.NewsItem, null);   var header = view.FindViewById<TextView>(Resource.Id.header);    var text = view.FindViewById<TextView>(Resource.Id.text);    var item = _items[position];    header.Text = item.Item1;    text.Text = item.Item2;    return view;
  ```21. Det sista vi behöver göra är att koppla adaptern till listan, det gör vi genom att sätta egenskapen ListAdapter i activityn till en instans av adaptern vi precis skapat.

	```csharp
	protected override void OnCreate(Bundle savedInstanceState){      base.OnCreate(savedInstanceState);      ListAdapter = new NewsAdapter(this);}
	```
22. Kör applikationen.                