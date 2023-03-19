namespace Library.Models
{
  public class ItemProperty
  {
    public int ItemPropertyId{get;set;}
    public int ItemId {get;set;}
    public Item Item {get; set;}
    public int PropertyId {get;set;}
    public Property Property {get; set;}
  }
}