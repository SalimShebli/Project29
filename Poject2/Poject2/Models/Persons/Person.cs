using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Poject2.Models.Persons
{
    public class Person
    {
        public int Id { get; set; }
       
        [StringLength(20)]
        public string fName { get; set; }
        [StringLength(20)]
        public string lName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public int PhoneNumber { get; set; }
        //
        public int personTypeId { get; set; }
        public PersonType personType { get; set; }
        //
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        //
        //don't create two account with one email
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(30)]
        public string PassWord { get; set; }
        public DateTime updateAt { set; get; }
        public DateTime CreateAt { get; set; }
        //
        public virtual List<Friend> ListFriend { get; set; }
        public virtual List<BlockPerson> ListBlock { get; set; }
        public virtual List<Notifaciton> ListNotifaction { get; set; }
        public virtual List<Post> ListPost { get; set; }
        public virtual List<Rating> ListRating { get; set; }
    }
}