using KavezoElszamolas;
List<Barista> Lista=new List<Barista>();
foreach (string beolvasott in File.ReadAllLines("baristak.txt"))
{
    string[] adatok=beolvasott.Split(";");
    Barista aktualis=new Barista();
    aktualis.Nev=adatok[0];
    aktualis.EladottKavek=int.Parse(adatok[1]);
    aktualis.NapiBevetelFt=int.Parse(adatok[2]);
    aktualis.RontottItalok=int.Parse(adatok[3]);
    Lista.Add( aktualis );
}
