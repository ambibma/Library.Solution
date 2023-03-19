namespace Library.Models
{
  public class Item
  {
    public int ItemId {get;set;}
    public ItemType ItemType {get;set;}
    public string DisplayName {get;set;}

  }
  
  public enum ItemType
  {
    
    Book,
    Media,
    Room,
    Misc
  }
}