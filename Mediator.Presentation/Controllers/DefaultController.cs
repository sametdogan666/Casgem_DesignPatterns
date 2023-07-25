﻿using Mediator.Presentation.MediatorPattern.Commands;
using Mediator.Presentation.MediatorPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Presentation.Controllers;

public class DefaultController : Controller
{
    private readonly IMediator _mediator;

    public DefaultController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ViewResult> Index()
    {
        var results = await _mediator.Send(new GetProductQuery());

        return View(results);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductCommand command)
    {
        await _mediator.Send(command);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _mediator.Send(new DeleteProductCommand(id));

        return RedirectToAction("Index");
    }
}