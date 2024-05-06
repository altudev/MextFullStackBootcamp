// See https://aka.ms/new-console-template for more information

using MextFullStack.Domain;
using MextFullStack.Domain.Entities;

Console.WriteLine("Hello, World!");


var customer = new Customer();

customer.Id = "12345";

var franchiseRep = new FranchiseRepresentative();

franchiseRep.Id = 1;

var franchise = new Franchise();

franchise.Id = Guid.NewGuid();

List<Customer> customers = new List<Customer>();

List<Franchise> franchises = new List<Franchise>();

List<FranchiseRepresentative> franchiseRepresentatives = new List<FranchiseRepresentative>();


Console.WriteLine(customer.CreatedOn.ToString());

Console.WriteLine(customer.Id.ToString());

Console.ReadLine();