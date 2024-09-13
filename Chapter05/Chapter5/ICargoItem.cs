namespace Packt.CloudySkiesAir.Chapter5;

public interface ICargoItem 
{
  string ItemType { get; }
  int Quantity { get; }
  string ManifestText => $"{ItemType} {Quantity}";

  void LongManifest() 
  {
    Console.WriteLine(ManifestText);
  }
}