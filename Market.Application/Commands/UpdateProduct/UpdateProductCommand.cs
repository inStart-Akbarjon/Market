<<<<<<< HEAD
﻿using Market.Application.DTOs.Request.Product;
using Market.Application.DTOs.Response.Product;
using Market.Domain.Models;
using MediatR;

namespace Market.Application.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdateProductResponse>
{
    
    public UpdateProductRequest _product  { get; set; }
    public UpdateProductCommand(UpdateProductRequest product)
    {
        _product = product;
    }
=======
﻿namespace Market.Application.Commands.UpdateProduct;

public class UpdateProductCommand
{
    
>>>>>>> 0cbf7de300fb8e8025bb247a7d8cffb5d24191fa
}