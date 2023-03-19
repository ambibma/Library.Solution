using System.Collections.Generic;

namespace Library.Models
{
  public class Property
  {
    public int PropertyId{get;set;}
    public int Value {get;set;}
    public PropertyType PropertyType {get; set;}
    public List<ItemProperty> JoinEntities {get;}
    
    
  }

  public enum PropertyType
  {
    Title,
    Author,
    ISBN,
    Genre,
    Size
  }
}