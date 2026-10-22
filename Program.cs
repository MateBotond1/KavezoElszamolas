using KavezoElszamolas;
using System.Runtime.InteropServices;
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
double teljesnapiossz = 0;
int osszkave = 0;
double legmagasabbfizetes = 0;
string legjobbdolgozo = "";
int rontottitaloknelkul = 0;
Console.WriteLine("Baristák napi elszámolása:");
for (int i = 0; i < Lista.Count; i++)
{
    int bonusz = 0;
    int levonas = 0;
    if (Lista[i].EladottKavek>=40 && Lista[i].RontottItalok <= 1) { bonusz = 8000; }
    if (Lista[i].RontottItalok >= 2) { levonas = 5000; }
    double fizetes = alapnapidij + (Lista[i].NapiBevetelFt * 0.04) + bonusz - levonas;
    teljesnapiossz+= fizetes;
    osszkave += Lista[i].EladottKavek;
    if (fizetes > legmagasabbfizetes) { legmagasabbfizetes = fizetes; legjobbdolgozo = Lista[i].Nev; }
    if (Lista[i].RontottItalok == 0){ rontottitaloknelkul += 1; }
    Console.WriteLine($"{Lista[i].Nev}: {Lista[i].EladottKavek} kávé, {Lista[i].NapiBevetelFt} Ft bevétel (Rontott: {Lista[i].RontottItalok}) - Fizetés: {fizetes} Ft");
}
double atlageladottkave = osszkave/Lista.Count;
Console.WriteLine("Összesített statisztika:");
Console.WriteLine($"Kávézó által kifizetett teljes összeg: {teljesnapiossz} Ft");
Console.WriteLine($"Átlagos eladott kávészám baristánként: {atlageladottkave:F0} kávé");
Console.WriteLine($"Legmagasabb napi fizetés: {legjobbdolgozo} ({legmagasabbfizetes} Ft)");
Console.WriteLine($"Rontott ital nélkül dolgozó baristák száma: {rontottitaloknelkul} fő");