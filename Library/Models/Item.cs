using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
  public class Item
  {
    public int ItemId {get;set;}
    public ItemType ItemType {get;set;}

    public string DisplayName {get;set;}
    // public ApplicationUser User {get;set;}
    public List<ItemProperty> JoinEntities {get;}
    
    // public List<Reservation> Reservations { get; set; }  ---is that it?
  }
  
  public enum ItemType
  {
    Book,
    Media,
    Room,
    Misc
  }

}