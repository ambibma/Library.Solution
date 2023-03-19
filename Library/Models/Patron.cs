namespace Library.Models
{
  public class Patron
  {
    public string PatronId {get;set;}
    public string Name {get; set;}
    
    //public int IsCardHolder{get;set;} //route to create cardholder form
    //public string Address{get; set;}
    public List<Reservation> Reservations {get;set;} // books, date checked out
    //public int OverDue{get;set;} 

    //public DateTime MyDateTimePlusTwoWeeks => MyDateTime.AddDays(14);
   

  }
}