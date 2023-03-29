namespace Library.Models
{
  public class Reservation
  {
    public int ReservationId { get; set; }
    public string CheckoutDate { get; set; }
    public int ItemId { get; set; }
    public Item Item {get; set;}
    public int PatronId { get; set; }
    public Patron Patron {get; set;}
    // public ApplicationUser User { get; set; }  
  }
}
