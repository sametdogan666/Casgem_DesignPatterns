﻿namespace UnitOfWork.Entities.Concrete;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Balance { get; set; }

}