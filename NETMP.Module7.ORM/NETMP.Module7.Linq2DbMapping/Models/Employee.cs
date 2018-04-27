using System;
using LinqToDB;
using LinqToDB.Mapping;

namespace NETMP.Module7.Linq2DbMapping.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Column("EmployeeID"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column, NotNull]
        public string LastName { get; set; }

        [Column, NotNull]
        public string FirstName { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string TitleOfCourtesy { get; set; }

        [Column]
        public DateTime? BirthDate { get; set; }

        [Column]
        public DateTime? HireDate { get; set; }

        [Column]
        public string Address { get; set; }

        [Column]
        public string City { get; set; }

        [Column]
        public string Region { get; set; }

        [Column]
        public string PostalCode { get; set; }

        [Column]
        public string Country { get; set; }

        [Column]
        public string HomePhone { get; set; }

        [Column]
        public string Extension { get; set; }

        [Column(DataType = DataType.Image)]
        public byte[] Photo { get; set; }

        [Column(DataType = DataType.NText)]
        public string Notes { get; set; }

        [Column]
        public int? ReportsTo { get; set; }

        [Column]
        public string PhotoPath { get; set; }


        [Association(ThisKey = "ReportsTo", OtherKey = "Id")]
        public Employee Reporter { get; set; }
    }
}
