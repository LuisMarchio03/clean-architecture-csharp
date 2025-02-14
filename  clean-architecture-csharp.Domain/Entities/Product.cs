﻿using clean_architecture_csharp.Domain.Validation;

namespace clean_architecture_csharp.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }
    
    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Id cannot be less than zero.");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }
    
    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be null or empty.");
        
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description cannot be null or empty.");
        
        DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters.");
        
        DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Image cannot be null or empty.");

        DomainExceptionValidation.When(image?.Length > 250, "Image cannot be longer than 250 characters.");
        
        DomainExceptionValidation.When(price < 0, "Price cannot be negative.");
        
        DomainExceptionValidation.When(stock < 0, "Invalid Stock Value.");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}