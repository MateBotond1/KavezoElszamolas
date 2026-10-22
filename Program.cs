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
int alapnapidij = 12000;
for (int i = 0; i < Lista.Count; i++)
{
    int bonusz = 0;
    int levonas = 0;
    if (Lista[i].EladottKavek>=40 && Lista[i].RontottItalok <= 1) { bonusz = 8000; }
    if (Lista[i].RontottItalok >= 2) { levonas = 5000; }
    double fizetes = alapnapidij + (Lista[i].NapiBevetelFt * 0.04) + bonusz - levonas;
}
